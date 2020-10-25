using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using Valve.VR;

//class used to grab rigidbody objects (optionally with selector tag)

public class GrabObject : MonoBehaviour
{
    private GameObject collidingObject;
    private GameObject holdingObject;
    private FixedJoint holdJoint;
    private Rigidbody rigidbody;
    public SteamVR_Input_Sources inputSource;
    public SteamVR_Behaviour_Pose pose;
    public SteamVR_Action_Boolean grabObject;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        collidingObject = other.gameObject;
    }

    private void OnTriggerExit(Collider other)
    {
        collidingObject = null;
    }

    private void Update()
    {
        if (grabObject.GetStateDown(inputSource) && collidingObject && !holdingObject && collidingObject.GetComponent<Rigidbody>())
        {
            holdJoint = new FixedJoint();
            holdJoint.connectedBody = collidingObject.GetComponent<Rigidbody>();
            holdingObject = collidingObject;
        }

        if (grabObject.GetLastStateUp(inputSource) && holdingObject)
        {
            Destroy(holdJoint);
        }
    }
}
