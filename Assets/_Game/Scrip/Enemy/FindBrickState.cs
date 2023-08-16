using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindBrickState : IState<Character>
{   
    Enemy enemy;
    int currentBricks;
    Transform target;
    public void OnEnter(Character t)
    {
        currentBricks = Random.Range(0, 10);
        target = enemy.SeekBrick();
        enemy.SetTarget(target);
    }

    public void OnExecute(Character t)
    {
        
    }

    public void OnExit(Character t)
    {

    }

}
