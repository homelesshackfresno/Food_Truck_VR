using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using UnityEngine.UI;

public class vrtoInput : MonoBehaviour
{
    public SteamVR_Action_Boolean up = null;

    public SteamVR_Action_Boolean down = null;

    private SteamVR_Behaviour_Pose pose = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if(up.GetStateDown(    ))
    }
}
