using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBrick : MonoBehaviour
{
   public Stack<GameObject> standingBlock = new Stack<GameObject>();

    [SerializeField]
    List<GameObject> stackBlockPrefab;

    [SerializeField]
    Transform ennemyBlock;

    [SerializeField]
    Enemy enemy;
    
    private void OnTriggerEnter(Collider other)
    {
        string tag = enemy.ColorSkin.ToString();
        if (other.CompareTag(Constants.TAG_BRICK) && Cache.GetEdibleBlock(other).colorSkin == enemy.ColorSkin )
        {
            GameObject go;
            go = InstantiateBlock(enemy.ColorSkin);
            go.transform.rotation = enemy.transform.rotation;
            standingBlock.Push(go);
        }
        else if (other.CompareTag(Constants.TAG_Step) && standingBlock.Count > 0 && Cache.GetInedibleBlock(other).ColorSkin != enemy.ColorSkin)
        {
            Destroy(standingBlock.Pop());
            Cache.GetInedibleBlock(other).state = enemy.state;
            Cache.GetInedibleBlock(other).ChangeColor(enemy.ColorSkin);  
        }
        else if (other.CompareTag(Constants.TAG_Win))
        {
            int length = standingBlock.Count - 1;
            for (int i = 0; i < length; i++)
            {
                Destroy(standingBlock.Pop());
            }
            other.transform.GetComponent<Animation>().Play();
        }else if (other.CompareTag(Constants.TAG_FinishPoint)){
            GameManager.Ins.IsPause = true;
            UIManager.Ins.OpenUI<Lose>();
        }
        
    }
    private void OnTriggerExit(Collider other) {
        if (other.CompareTag(Constants.TAG_Win)){
            other.transform.GetComponent<Collider>().isTrigger = false;
            other.gameObject.tag = Constants.TAG_BRICK;
        }
    }
    private GameObject InstantiateBlock(ColorSkin color){
        foreach(GameObject obj in stackBlockPrefab){
            if(obj.name == color.ToString()){
                GameObject go = Instantiate(obj, StackPos(), Quaternion.identity, ennemyBlock );
                return go;
            }
        }
        return null;
        
    }
    Vector3 StackPos()
    {
        Vector3 v3;
        if(standingBlock.Count == 0){
            v3 = ennemyBlock.transform.position + new Vector3(0, 0, 0);
            
        }else{
            v3 = ennemyBlock.transform.position + new Vector3(0, standingBlock.Count * 0.325f, 0);
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
