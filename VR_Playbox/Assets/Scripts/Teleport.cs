using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Teleport : MonoBehaviour
{
    public SteamVR_Input_Sources inputSource;
    public SteamVR_Behaviour_Pose controllerPose;
    public SteamVR_Action_Boolean laserAction;
    public SteamVR_Action_Boolean teleportAction;

    public GameObject laserPrefab;
    public int maxDistance = 100;
    private GameObject laser;

    private void Start()
    {
        laser = Instantiate(laserPrefab);
    }

    private void Update()
    {
        if (laserAction.GetState(inputSource))
        {
            RaycastHit hit;

            if (Physics.Raycast(controllerPose.transform.position, transform.forward, out hit, maxDistance))
            {
                Laser.ShowLaser(controllerPose.transform.position, hit.point, laser);
            }
        }
        else
        {
            laser.SetActive(false);
        }
    }
}
