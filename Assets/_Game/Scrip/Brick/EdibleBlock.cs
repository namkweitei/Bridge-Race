using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdibleBlock : MonoBehaviour
{
    private  void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")&& other.GetComponent<Player>().Color.ToString() == gameObject.tag )
        {
            BrickSpawner.Instance.Despawn(transform);
        }
    }
}
