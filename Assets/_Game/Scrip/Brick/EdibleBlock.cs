using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdibleBlock : MonoBehaviour
{
    public ColorSkin colorSkin;
    
    private  void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && other.GetComponent<PlayerMove>().ColorSkin == colorSkin )
        {
            BrickSpawner.Instance.Despawn(transform);
        }
    }
}
