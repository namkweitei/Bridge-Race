using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IState<Character>
{
    Enemy enemy;
    float timer;
    public void OnEnter(Character t)
    {
        timer = 1;
    }

    public void OnExecute(Character t)
    {
        timer -= Time.deltaTime;
        if (timer < 0){
            enemy.ChangeState(new FindBrickState());
        }
    }

    public void OnExit(Character t)
    {

    }

}
