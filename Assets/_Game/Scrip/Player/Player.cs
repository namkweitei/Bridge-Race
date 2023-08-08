using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private float speed = 5f;
    [SerializeField] private ColorSkin color;
    public ColorSkin Color { get { return color; } }
    private float horizontal;
    private float vertical;
    private void Update()
    {
        horizontal = UltimateJoystick.GetHorizontalAxis("PlayerJoystick");
        vertical = UltimateJoystick.GetVerticalAxis("PlayerJoystick");
    }

    private void FixedUpdate()
    {

        JoystickMovement();
        Rotate();

    }

    protected virtual void JoystickMovement()
    {
        //rb.velocity = new Vector3(horizontal * speed, rb.velocity.y, vertical * speed);
        Vector3 movement = new Vector3(horizontal, 0f, vertical).normalized;
        Vector3 moveDestination = transform.position + speed * Time.deltaTime * movement;

        agent.SetDestination(moveDestination);
    }

    protected virtual void Rotate()
    {
        if (horizontal != 0 || vertical != 0 )
        {
            float targetAngle = Mathf.Atan2(horizontal, vertical) * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.Euler(0f, targetAngle, 0f);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * 10);
        }
    }
    public bool GetMove(){
        return horizontal != 0 || vertical != 0; 
    }
}
