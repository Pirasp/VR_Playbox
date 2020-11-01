using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetGameItems : MonoBehaviour
{

    public GameObject[] gameItems;
    public Transform[] gameItemPositions;
    
    void Start()
    {
        for (int i = 0; i < gameItems.Length; i++)
        {
            gameItemPositions[i] = gameItems[i].transform;
        }
    }

    public void ResetItems()
    {
        for (int i = 0; i < gameItems.Length; i++)
        {
            gameItems[i].transform.position = gameItemPositions[i].position;
            gameItems[i].transform.rotation = gameItemPositions[i].rotation;
        }
    }
}
