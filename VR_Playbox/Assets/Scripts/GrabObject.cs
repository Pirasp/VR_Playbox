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
    public bool useTag;
    public string tag;

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
            if ((useTag && collidingObject.tag == tag) || !useTag)
            {
                holdJoint = gameObject.AddComponent<FixedJoint>();
                holdJoint.breakForce = float.PositiveInfinity;
                holdJoint.breakTorque = float.PositiveInfinity;
                holdJoint.connectedBody = collidingObject.GetComponent<Rigidbody>();
                holdingObject = collidingObject;
                holdingObject.SendMessage("Grab", SendMessageOptions.DontRequireReceiver);
            }
        }

        if (grabObject.GetLastStateUp(inputSource) && holdingObject)
        {

                holdJoint.connectedBody = null;
                Destroy(holdJoint);
                
                holdingObject.SendMessage("Release", SendMessageOptions.DontRequireReceiver);
                
                holdingObject.GetComponent<Rigidbody>().velocity = pose.GetVelocity();
                holdingObject.GetComponent<Rigidbody>().angularVelocity = pose.GetAngularVelocity();

                holdingObject = null;
        }
            
    }
}
