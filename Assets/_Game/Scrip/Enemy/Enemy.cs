using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] ColorData colorData;
    [SerializeField] Renderer meshRenderer;
    [SerializeField] EnemyBrick enemyBrick;
    public NavMeshAgent agent;
    public Transform finishTarget;
    [SerializeField] public Animator animator;
    public ColorSkin ColorSkin;
    public State state;
    private IState<Enemy> currentState;

    // Start is called before the first frame update
    public void OnInit(){
        ChangeState(new IdleState());
        ChangeColor(ColorSkin);
        agent.stoppingDistance = 0;
    }
    // Update is called once per frame
    protected void Update()
    {
        if(GameManager.Ins.IsPause)
        {
            ChangeState(new IdleState());
        return;
        }
        if (currentState != null)
        {
            currentState.OnExecute(this);
        }
    }
 
    public int CheckBridge()
    {
        return enemyBrick.standingBlock.Count ;
    }
    public void ClearBrick(){
        int length = enemyBrick.standingBlock.Count - 1;
            for (int i = 0; i <= length; i++)
            {
                Destroy(enemyBrick.standingBlock.Pop());
            }
    }
    [ContextMenu("123")]
    public EdibleBlock SeekBrick(){
        EdibleBlock target = null;
        for(int i = 0; i< state.Bricks.Count; i++){
            if(state.Bricks[i].colorSkin == ColorSkin && state.Bricks[i].gameObject.activeSelf){
                target = state.Bricks[i];
                state.Shuffle();
            }
        } 
        return target;
    }
    public void SetTarget(Transform target)
    {
        agent.SetDestination(target.position);
    }
    public void Stop(){
        agent.SetDestination(transform.position);
    }
    public void SetFinishLine(){
        agent.SetDestination(finishTarget.position);
    }
     public void ChangeColor(ColorSkin colorType)
    {
        ColorSkin = colorType;
        meshRenderer.material = colorData.GetMaterial(colorType);
    }
     public void ChangeState(IState<Enemy> state)
    {
        if (currentState != null)
        {
            currentState.OnExit(this);
        }

        currentState = state;

        if (currentState != null)
        {
            currentState.OnEnter(this);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag(Constants.TAG_State)){
            if(other.transform.GetComponent<State>() != this.state){
                this.state = other.transform.GetComponent<State>();
                this.state.SpawnFirstBrick(ColorSkin);
            }
            
            
        }
    }
}
