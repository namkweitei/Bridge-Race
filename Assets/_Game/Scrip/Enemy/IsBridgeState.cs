using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsBridgeState : IState<Enemy>
{

    public void OnEnter(Enemy t)
    {
        t.SetFinishLine();
        t.animator.SetFloat("Speed",2);
    }

    public void OnExecute(Enemy t)
    {
        
        if(t.CheckBridge() <= 0 ){
            t.ChangeState(new FindBrickState());
        }
    }
    

    public void OnExit(Enemy t)
    {

    }

}
