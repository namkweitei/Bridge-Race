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

   [SerializeField] protected Transform holder;
    [SerializeField] protected List<Transform> prefabs;
    [SerializeField] protected List<Transform> poolObj;

    // Start is called before the first frame update
    protected virtual void Reset()
    {
        this.LoadComponents();
    }
    protected virtual void Awake()
    {
        this.LoadComponents();
    }
    protected void LoadComponents()
    {
        this.LoadHolder();
        this.LoadPrefabs();
    }
    protected virtual void LoadHolder()
    {
        if (this.holder != null) return;
        this.holder = this.transform.Find("Holder");
    }

    protected virtual void LoadPrefabs()
    {
        if (this.prefabs.Count > 0) return;
        
        Transform prefabObj = this.transform.Find("Prefabs");
        foreach (Transform prefab in prefabObj)
        {
            this.prefabs.Add(prefab);
        }
        this.HidePrefabs();
    }
    protected virtual void HidePrefabs()
    {
        foreach (Transform prefab in this.prefabs)
        {
            prefab.gameObject.SetActive(false);
        }
    }
    public virtual Transform Spawn(ColorSkin colorSkin)
    {
        Transform prefab = this.GetPrefabByName(colorSkin);
        if(prefab == null)
        {
            Debug.LogError("Prefab not found" + colorSkin);
            return null;
        }
        Transform newPrefab = this.GetObjectFromPool(prefab);
        newPrefab.parent = this.holder;
        newPrefab.gameObject.SetActive(true);
        return newPrefab;
    }

    protected virtual Transform GetObjectFromPool(Transform prefab)
    {
        foreach (Transform obj in this.poolObj)
        {
            if (obj.name == prefab.name)
            {
                this.poolObj.Remove(obj);
                return obj;
            }
        }
        Transform newPrefab = Instantiate(prefab);
        newPrefab.name = prefab.name;
        return newPrefab;
    }

    public virtual void Despawn(Transform obj)
    {
        this.poolObj.Add(obj);
        obj.gameObject.SetActive(false);
    }
    public virtual Transform GetPrefabByName(ColorSkin colorSkin)
    {
        foreach (Transform prefab in this.prefabs)
        {
            if (prefab.name == colorSkin.ToString())
            {
                return prefab;
            }
        }
        return null;
    }


}
