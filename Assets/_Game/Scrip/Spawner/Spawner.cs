using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum ColorSkin{
    Blue,
    Red,
    Yellow,
}
public abstract class Spawner : MonoBehaviour
{
    [SerializeField] protected Transform blue;
    [SerializeField] protected Transform red;
    [SerializeField] protected Transform yellow;
    [SerializeField] protected Transform violet;
    [SerializeField] protected List<Transform> prefabs;
    [SerializeField] protected List<Transform> poolObj;

    // Start is called before the first frame update
    private void Reset() {
        LoadComponents();
    }
    protected virtual void Awake() {
        LoadComponents();
    }
    protected void LoadComponents()
    {
        this.LoadHolder();
    }
    protected virtual void LoadHolder()
    {
        if (this.blue != null || this.red != null || this.yellow != null || this.violet != null) return;
        this.blue = this.transform.Find("Blue");
        this.red = this.transform.Find("Red");
        this.yellow = this.transform.Find("Yellow");
        this.violet = this.transform.Find("Violet");
    }
    public virtual Transform Spawn(ColorSkin block)
    {
        Transform newPrefab = this.GetObjectFromPool(block);
        if (newPrefab == null) return null;
        newPrefab.gameObject.SetActive(true);
        return newPrefab;
    }

    protected virtual Transform GetObjectFromPool(ColorSkin block)
    {
        foreach (Transform obj in this.poolObj)
        {
            if (obj.name == block.ToString())
            {
                this.poolObj.Remove(obj);
                return obj;
            }
        }
        return null;

    }

    public virtual void Despawn(Transform obj)
    {
        this.poolObj.Add(obj);
        obj.gameObject.SetActive(false);
    }
    public virtual Transform GetPrefabByName(string prefabName)
    {
        foreach (Transform prefab in this.prefabs)
        {
            if (prefab.name == prefabName)
            {
                return prefab;
            }
        }
        return null;
    }


}
