using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetBrick : MonoBehaviour
{
    private static SetBrick instance;
    public static SetBrick Instance
    {
        get
        {
            return instance;
        }
    }
    [SerializeField] protected List<Transform> Holder;
    [SerializeField] protected List<Transform> Plane;
    [SerializeField] protected int currentPlane = 1;
    protected void Awake()
    {
        if (SetBrick.instance != null)
        {
            Debug.LogError("More than one InputManager in the scene");
        }
        SetBrick.instance = this;
    }
    public void NextPlane(ColorSkin colorSkin){
        this.Holder[(int)colorSkin].transform.position = Plane[currentPlane].position + new Vector3(0f,0.5f,0f);
        currentPlane++;
    }
}
