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
    [SerializeField] protected List<Transform> Holder;
    [SerializeField] protected List<Transform> Plane;
    [SerializeField] protected int currentPlane = 1;
    protected override void Awake()
    {
        if (BrickSpawner.instance != null)
        {
            Debug.LogError("More than one InputManager in the scene");
        }
        BrickSpawner.instance = this;
        base.Awake();
    }
    protected override void LoadHolder(){
        if (this.Holder.Count > 0 ) return;
        this.Holder.Add(this.transform.Find("Blue"));
        this.Holder.Add(this.transform.Find("Red"));
        this.Holder.Add(this.transform.Find("Yellow"));
        this.Holder.Add(this.transform.Find("Violet"));
    }
    public void NextPlane(ColorSkin colorSkin){
        this.Holder[(int)colorSkin].transform.position = Plane[currentPlane].position + new Vector3(0f,0.5f,0f);
        currentPlane++;
    }
}
