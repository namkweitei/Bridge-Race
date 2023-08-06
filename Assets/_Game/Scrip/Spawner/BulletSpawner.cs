using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : Spawner
{
    private static BulletSpawner instance;
    public static BulletSpawner Instance
    {
        get
        {
            return instance;
        }
    }
    public static string bulletOne = "Bullet_1";
    protected override void Awake()
    {
        if (BulletSpawner.instance != null)
        {
            Debug.LogError("More than one InputManager in the scene");
        }
        BulletSpawner.instance = this;
        base.Awake();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
