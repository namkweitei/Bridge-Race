using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindBrickState : IState<Enemy>
{   
    int currentBricks;
    Transform target;
    public void OnEnter(Enemy t)
    {
        currentBricks = Random.Range(0, 10);
        target = t.SeekBrick();
        t.SetTarget(target);
    }

    public void OnExecute(Enemy t)
    {
        if(t.agent.remainingDistance <= t.agent.stoppingDistance){
            if(t.CheckBridge() >= currentBricks){
                t.ChangeState(new IsBridgeState());
            }else{
                target = t.SeekBrick();
                t.SetTarget(target);
            //    t.ChangeState(new FindBrickState());
            }
        }
    }

    public void OnExit(Enemy t)
    {

    }

}
