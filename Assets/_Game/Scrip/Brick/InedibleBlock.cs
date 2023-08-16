using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InedibleBlock : MonoBehaviour
{
    [SerializeField] ColorData colorData;
    [SerializeField] Renderer meshRenderer;
    public ColorSkin ColorSkin;
    public State state;
 
    public void ChangeColor(ColorSkin colorType)
    {   
        ColorSkin = colorType;
        meshRenderer.material = colorData.GetMaterial(colorType);
        state.SpawnSecondBrick(colorType);
    }
}
