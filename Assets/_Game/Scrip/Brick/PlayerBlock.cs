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
    Player player;
    
    private void OnTriggerEnter(Collider other)
    {
        string tag = player.ColorSkin.ToString();
        if (other.CompareTag(Constants.TAG_BRICK) && Cache.GetEdibleBlock(other).colorSkin == player.ColorSkin )
        {
            GameObject go;
            go = InstantiateBlock(player.ColorSkin);
            go.transform.rotation = playerBlock.transform.rotation;
            standingBlock.Push(go);
        }
        else if (other.CompareTag(Constants.TAG_Step) && standingBlock.Count > 0 && Cache.GetInedibleBlock(other).ColorSkin != player.ColorSkin)
        {

            Destroy(standingBlock.Pop());
            Cache.GetInedibleBlock(other).state = player.state;
            Cache.GetInedibleBlock(other).ChangeColor(player.ColorSkin);  
        }
        else if (other.CompareTag(Constants.TAG_Win))
        {
            int length = standingBlock.Count - 1;
            for (int i = 0; i < length; i++)
            {
                Destroy(standingBlock.Pop());
            }
            other.transform.GetComponent<Animation>().Play();

        }
        
    }
    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.CompareTag(Constants.TAG_FinishPoint)){
            int length = standingBlock.Count - 1;
            for (int i = 0; i < length; i++)
            {
                Destroy(standingBlock.Pop());
            }
            GameManager.Ins.IsPause = true;
            UIManager.Ins.OpenUI<Win>();
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
