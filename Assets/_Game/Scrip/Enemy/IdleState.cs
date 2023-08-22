using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IState<Enemy>
{
    Enemy enemy;
    float timer;
    public void OnEnter(Enemy t)
    {
        timer = 1;
        t.animator.SetFloat("Speed",0);
        t.Stop();
    }

    public void OnExecute(Enemy t)
    {
        timer -= Time.deltaTime;
        if (timer < 0){
            t.ChangeState(new FindBrickState());
        }
    }

    public void OnExit(Enemy t)
    {

    }

}
