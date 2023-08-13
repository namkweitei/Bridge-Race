using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum ColorSkin{
    Blue,
    Red,
    Yellow,
    Violet,
    None
}
public abstract class Spawner : MonoBehaviour
{

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
