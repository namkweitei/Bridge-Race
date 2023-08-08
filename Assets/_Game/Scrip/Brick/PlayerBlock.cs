using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBlock : MonoBehaviour
{
    private Stack<GameObject> standingBlock = new Stack<GameObject>();

    [SerializeField]
    List<GameObject> stackBlockPrefab;

    [SerializeField]
    Transform playerBlock;

    [SerializeField]
    GameObject playerModel;

    [SerializeField]
    Animator animator;
    [SerializeField]
    Player player;
    
    private void Start()
    {
        Debug.Log(".");

    }

    private void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        string tag = player.Color.ToString();
        if (other.CompareTag(tag) )
        {
            Debug.Log("..");
            GameObject go;
            go = InstantiateBlock(player.Color);
            go.transform.rotation = playerBlock.transform.rotation;
            standingBlock.Push(go);
        }
        else if (other.CompareTag("Step") && standingBlock.Count > 0)
        {
            Destroy(standingBlock.Pop());
        }
        // else if (other.CompareTag("Win"))
        // {
        //     int length = standingBlock.Count - 1;
        //     for (int i = 0; i < length; i++)
        //     {
        //         Destroy(standingBlock.Dequeue());
        //     }

        // }else if (other.CompareTag("FinishLine"))
        // {
        //     animator.SetInteger("Play", 2);
        //     Invoke(nameof(OpenWin), 3f);
        // }
    }

    private GameObject InstantiateBlock(ColorSkin color){
        foreach(GameObject obj in stackBlockPrefab){
            if(obj.name == color.ToString()){
                GameObject go = Instantiate(obj, StackPos(), Quaternion.identity, playerBlock );
                return go;
            }
        }
        return null;
        
    }
    Vector3 StackPos()
    {
        Vector3 v3;
        if(standingBlock.Count == 0){
            v3 = playerBlock.transform.position + new Vector3(0, 0, 0);
            
        }else{
            v3 = playerBlock.transform.position + new Vector3(0, standingBlock.Count * 0.325f, 0);
        }
        
        return v3;
    }
    public int CoutBrick()
    {
        return standingBlock.Count;
    }
    protected void OpenWin()
    {

    }
}
