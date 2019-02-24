using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Interactable : MonoBehaviour
{
    [HideInInspector]
    public Hand ActiveHand = null;

    private bool atSpawn = true;

    private float despawnCountdown = 2f;


    private void Start()
    {
        atSpawn = true;
        this.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
    }

    private void Update()
    {
        if(!atSpawn && this.GetComponent<Rigidbody>().velocity.magnitude <= .2f)
        {
            if(despawnCountdown <= 0)
            {
                Destroy(this.gameObject);
            }
            else
            {
                despawnCountdown -= Time.deltaTime;
            }
        }
    }

    public void LeaveSafe()
    {
        atSpawn = false;
    }

    public void ReturnToSafe()
    {
        atSpawn = true;
        despawnCountdown = 2f;
    }
}
