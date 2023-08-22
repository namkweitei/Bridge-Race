using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Cache 
{
    private static Dictionary<Collider, EdibleBlock> dictEdibleBlock = new Dictionary<Collider, EdibleBlock>();
    private static Dictionary<Collider, InedibleBlock> dictInedibleBlock = new Dictionary<Collider, InedibleBlock>();
    private static Dictionary<RaycastHit, InedibleBlock> dictRaycastInedibleBlock = new Dictionary<RaycastHit, InedibleBlock>();
    private static Dictionary<RaycastHit, Collider> dictRaycastCollider = new Dictionary<RaycastHit, Collider>();
    public static EdibleBlock GetEdibleBlock(Collider col){
        if(!dictEdibleBlock.ContainsKey(col)){
            EdibleBlock edibleBlock = col.GetComponent<EdibleBlock>();
            dictEdibleBlock.Add(col, edibleBlock);
        }
        return dictEdibleBlock[col];
    }
    public static InedibleBlock GetInedibleBlock(Collider col){
        if(!dictInedibleBlock.ContainsKey(col)){
            InedibleBlock edibleBlock = col.GetComponent<InedibleBlock>();
            dictInedibleBlock.Add(col, edibleBlock);
        }
        return dictInedibleBlock[col];
    }
    public static InedibleBlock GetRaycastInedibleBlock(RaycastHit hit ){
        if(!dictRaycastInedibleBlock.ContainsKey(hit)){
            InedibleBlock edibleBlock = hit.transform.GetComponent<InedibleBlock>();
            dictRaycastInedibleBlock.Add(hit, edibleBlock);
        }
        return dictRaycastInedibleBlock[hit];
    }
    public static Collider GetRaycastCollider(RaycastHit hit ){
        if(!dictRaycastCollider.ContainsKey(hit)){
            Collider edibleBlock = hit.transform.GetComponent<Collider>();
            dictRaycastCollider.Add(hit, edibleBlock);
        }
        return dictRaycastCollider[hit];
    }
}
