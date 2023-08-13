using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private PlayerMove player;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if(player.GetMove()){
            animator.SetFloat("Speed",2);
        }else{
            animator.SetFloat("Speed", 0);
        }
    }
}
