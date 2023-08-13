using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    private IState<Character> currentState;

    protected virtual void Start()
    {
        ChangeState(new IdleState());
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (currentState != null)
        {
            currentState.OnExecute(this);
        }
    }

    public void ChangeState(IState<Character> state)
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

}
