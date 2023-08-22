using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : Singleton<StateManager>
{
    [SerializeField] private List<State> states;
    [SerializeField] private Transform finishPoint;
    public Transform GetFinishPoint(){
        return finishPoint;
    }
    
}
