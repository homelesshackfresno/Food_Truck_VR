using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using UnityEngine.UI;

public class Hand : MonoBehaviour
{
    public SteamVR_Action_Boolean grabAction = null;

    private SteamVR_Behaviour_Pose pose = null;
    private FixedJoint joint = null;

    private SteamVR_Action_Boolean interactWithUi = null;
    public SteamVR_Action_Vibration _Out = null;

    public SteamVR_Action_Boolean up = null;

    public SteamVR_Action_Boolean down = null;

    private Interactable currentInteractable = null;
    private List<Interactable> contactInteractables = new List<Interactable>();

    // Added Velocity constant
    public float addedThrowVelocity = 2f;

    private void Awake()
    {
        pose = GetComponent<SteamVR_Behaviour_Pose>();
        joint = GetComponent<FixedJoint>();
    }

    // Update is called once per frame
    void Update()
    {
        // Down
        if(grabAction.GetStateDown(pose.inputSource))
        {
            print(pose.inputSource + "Trigger DOWN");
            Pickup();
        }

        // Up
        if (grabAction.GetStateUp(pose.inputSource))
        {
            print(pose.inputSource + "Trigger UP");
            Drop();
        }

        if(up.GetStateDown(pose.inputSource))
        {
              Debug.Log("Hit!");
            RaycastHit hit;

            Ray r = new Ray(this.transform.position, this.transform.up);

            if (Physics.Raycast(r))
            {
  
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(!other.gameObject.CompareTag("Interactable"))
        {
            return;
        }
        
        //_Out.
        contactInteractables.Add(other.GetComponent<Interactable>());
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.gameObject.CompareTag("Interactable"))
        {
            return;
        }
        contactInteractables.Remove(other.GetComponent<Interactable>());
    }

    public void Pickup()
    {
        // Get Nearest
        currentInteractable = GetNearestInteractable();

        // Null Check
        if (!currentInteractable)
            return;

        //If held by other => drop
        if (currentInteractable.ActiveHand)
            currentInteractable.ActiveHand.Drop();

        // Position
        currentInteractable.transform.position = transform.position;

        // Attach
        Rigidbody targetBody = currentInteractable.GetComponent<Rigidbody>();
        joint.connectedBody = targetBody;


        // Set active hand
        currentInteractable.ActiveHand = this;

    }

    public void Drop()
    {
        //Null Check
        if (!currentInteractable)
            return;

        // Apply velocity
        Rigidbody TargetBody = currentInteractable.GetComponent<Rigidbody>();
        TargetBody.velocity = pose.GetVelocity() * addedThrowVelocity;
        TargetBody.angularVelocity = pose.GetAngularVelocity();

        // Detach
        joint.connectedBody = null;

        // Clear
        currentInteractable.ActiveHand = null;
        currentInteractable = null;
    }

    private Interactable GetNearestInteractable()
    {
        Interactable nearest = null;
        float minDist = float.MaxValue;
        float dist = 0f;

        foreach(Interactable interactable in contactInteractables)
        {
            dist = (interactable.transform.position - transform.position).sqrMagnitude;
            if(dist < minDist)
            {
                minDist = dist;
                nearest = interactable;
            }
        }

        return nearest;
    }

    private void Start()
    {
        Debug.Log(up.GetType());
    }
}
