using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowManager : MonoBehaviour
{
    public static ThrowManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(this);
    }

    public int maxballs = 15;
    public int curballs = 1;

}
