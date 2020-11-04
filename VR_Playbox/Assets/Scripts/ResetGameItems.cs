using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetGameItems : MonoBehaviour
{

    public GameObject[] gameItems;
    public Vector3[] gameItemPositions;
    public Quaternion[] gameItemRotations;
    
    void Start()
    {
        for (int i = 0; i < gameItems.Length; i++)
        {
            gameItemPositions[i] = gameItems[i].transform.position;
            gameItemRotations[i] = gameItems[i].transform.rotation;
        }
    }

    public void ResetItems()
    {
        for (int i = 0; i < gameItems.Length; i++)
        {
            gameItems[i].transform.position = gameItemPositions[i];
            gameItems[i].transform.rotation = gameItemRotations[i];

        }
    }
}
