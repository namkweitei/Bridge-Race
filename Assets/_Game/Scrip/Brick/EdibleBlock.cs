using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdibleBlock : MonoBehaviour
{
    public ColorSkin colorSkin;
    public float shrinkDuration = 1.0f; 

    private void Start()
    {
        StartCoroutine(ShrinkAndDisappearCoroutine());
    }

    private IEnumerator ShrinkAndDisappearCoroutine()
    {
        float timer = 0f;
        Vector3 initialScale = transform.localScale;

        while (timer < shrinkDuration)
        {
            timer += Time.deltaTime;
            float scale = timer / shrinkDuration;
            transform.localScale = initialScale * scale;
            yield return null;
        }
    }
    private  void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && other.GetComponent<Player>().ColorSkin == colorSkin )
        {
            BrickSpawner.Ins.Despawn(transform);
        }else if (other.CompareTag("Enemy") && other.GetComponent<Enemy>().ColorSkin == colorSkin )
        {
            BrickSpawner.Ins.Despawn(transform);
        }
    }
}
