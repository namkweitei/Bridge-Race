using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InedibleBlock : MonoBehaviour
{
    [SerializeField] private MeshRenderer meshRenderer;
    [SerializeField] private List<Material> materials;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            meshRenderer.enabled = true;
            meshRenderer.material = materials[(int)other.GetComponent<Player>().Color];
            BrickSpawner.Instance.Spawn(other.GetComponent<Player>().Color);
        }
    }
}
