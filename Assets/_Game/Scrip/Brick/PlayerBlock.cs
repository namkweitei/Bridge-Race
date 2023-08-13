using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBlock : MonoBehaviour
{
    public Stack<GameObject> standingBlock = new Stack<GameObject>();

    [SerializeField]
    List<GameObject> stackBlockPrefab;

    [SerializeField]
    Transform playerBlock;

    [SerializeField]
    Animator animator;
    [SerializeField]
    PlayerMove player;
    
    private void OnTriggerEnter(Collider other)
    {
        string tag = player.ColorSkin.ToString();
        if (other.CompareTag("Brick") && other.GetComponent<EdibleBlock>().colorSkin == player.ColorSkin )
        {
            GameObject go;
            go = InstantiateBlock(player.ColorSkin);
            go.transform.rotation = playerBlock.transform.rotation;
            standingBlock.Push(go);
        }
        else if (other.CompareTag("Step") && standingBlock.Count > 0 && other.transform.GetComponent<InedibleBlock>().ColorSkin != player.ColorSkin)
        {
            Destroy(standingBlock.Pop());
            other.transform.GetComponent<InedibleBlock>().ChangeColor(player.ColorSkin);
        }
        else if (other.CompareTag("Win"))
        {
            int length = standingBlock.Count - 1;
            for (int i = 0; i < length; i++)
            {
                Destroy(standingBlock.Pop());
            }
            BrickSpawner.Instance.NextPlane(player.ColorSkin);
            other.transform.GetComponent<Animation>().Play();
            Debug.Log("...");

        }
        // }else if (other.CompareTag("FinishLine"))
        // // {
        // //     animator.SetInteger("Play", 2);
        // //     Invoke(nameof(OpenWin), 3f);
        // // }
    }
    private void CloseDoor(Collider other){
        other.transform.GetComponent<Collider>().isTrigger = false;
        other.gameObject.tag = "Untagged";
    }
    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Win")){
            other.transform.GetComponent<Collider>().isTrigger = false;
            other.gameObject.tag = "Untagged";
        }
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
