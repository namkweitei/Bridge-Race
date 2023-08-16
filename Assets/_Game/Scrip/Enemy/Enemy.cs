using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] ColorData colorData;
    [SerializeField] Renderer meshRenderer;
    [SerializeField] EnemyBrick enemyBrick;
    [SerializeField] public NavMeshAgent agent;
    [SerializeField] Transform finishTarget;
    public ColorSkin ColorSkin;
    public State state;
    private IState<Enemy> currentState;

    // Start is called before the first frame update
    protected void Start()
    {
        ChangeState(new IdleState());
        ChangeColor(ColorSkin);
        agent.stoppingDistance = 0;
    }

    // Update is called once per frame
    protected void Update()
    {
        Debug.Log(currentState);
        if (currentState != null)
        {
            currentState.OnExecute(this);
        }
    }
 
    public int CheckBridge()
    {
        return enemyBrick.standingBlock.Count ;
    }
    [ContextMenu("123")]
    public Transform SeekBrick(){
        Transform target = null;
        for(int i = 0; i< state.Bricks.Count; i++){
            if(state.Bricks[i].gameObject.name == ColorSkin.ToString() && state.Bricks[i].gameObject.activeSelf){
                target = state.Bricks[i];
            }
        } 
        return target;
    }
    public void SetTarget(Transform target)
    {
        agent.SetDestination(target.position);
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
        if(other.CompareTag("State")){
            Debug.Log("");
            if(other.transform.GetComponent<State>() != this.state){
                this.state = other.transform.GetComponent<State>();
                this.state.SpawnFirstBrick(ColorSkin);
            }
            
            
        }
    }
}
