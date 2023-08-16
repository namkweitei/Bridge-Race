using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : Character
{
    [SerializeField] ColorData colorData;
    [SerializeField] Renderer meshRenderer;
    [SerializeField] EnemyBrick enemyBrick;
    [SerializeField] NavMeshAgent agent;
    public ColorSkin ColorSkin;
    public State state;


    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        ChangeColor(ColorSkin);
        
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        CheckBridge();
    }
 
    public bool CheckBridge()
    {
        return enemyBrick.standingBlock.Count > 0;
    }
    [ContextMenu("123")]
    public Transform SeekBrick(){
        Transform target = null;
        foreach(Transform brick in state.Bricks){
            if(brick.gameObject.name == ColorSkin.ToString()){
                target = brick;
            }else{
                target = null;
            }
        }
        Debug.Log(target);
        return target;
    }
    public void SetTarget(Transform target)
    {
        agent.SetDestination(target.position);
    }
     public void ChangeColor(ColorSkin colorType)
    {
        ColorSkin = colorType;
        meshRenderer.material = colorData.GetMaterial(colorType);
    }
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("State")){
            this.state = other.transform.GetComponent<State>();
            state.SpawnFirstBrick(ColorSkin);
        }
    }
}
