using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "ColorData", menuName = "ColorData", order = 1)]
public class ColorData : ScriptableObject
{
    public Material[] materials;
    public Material GetMaterial(ColorSkin colorSkin)
    {
        return materials[(int)colorSkin];
    }
}
