using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InedibleBlock : MonoBehaviour
{
    [SerializeField] ColorData colorData;
    [SerializeField] Renderer meshRenderer;
    public ColorSkin ColorSkin;

    //private void OnTriggerEnter(Collider other )
    //{
    //    Player player = other.GetComponent<Player>();
    //    if (other.CompareTag("Player") && player.Color != Color)
    //    {
    //        Color = player.Color;
    //        meshRenderer.enabled = true;
    //        meshRenderer.material = colorData.GetMaterial(player.Color);
    //        BrickSpawner.Instance.Spawn(player.Color);
    //    }
    //}
    public void ChangeColor(ColorSkin colorType)
    {
        ColorSkin = colorType;
        meshRenderer.material = colorData.GetMaterial(colorType);
        BrickSpawner.Instance.Spawn(colorType);
    }
}
