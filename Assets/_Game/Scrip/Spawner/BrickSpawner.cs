using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickSpawner : Spawner
{
     private static BrickSpawner instance;
    public static BrickSpawner Instance
    {
        get
        {
            return instance;
        }
    }
    
    protected override void Awake()
    {
        base.Awake();
        if (BrickSpawner.instance != null)
        {
            Debug.LogError("More than one InputManager in the scene");
        }
        BrickSpawner.instance = this;
    }
}
