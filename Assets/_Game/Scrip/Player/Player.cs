
using Microsoft.VisualBasic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] private float speed = 5f;
    [SerializeField] ColorData colorData;
    [SerializeField] Renderer meshRenderer;
    [SerializeField] PlayerBlock PlayerBlock;
    public ColorSkin ColorSkin;
    public State state;
    public bool isMove;
    private float horizontal;
    private float vertical;
    public LayerMask stepLayer;
    Vector3 dir;


    // Start is called before the first frame update
    void Start()
    {
        ChangeColor(ColorSkin);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Ins.IsPause) {
            return;
        }
        horizontal = UltimateJoystick.GetHorizontalAxis("PlayerJoystick");
        vertical = UltimateJoystick.GetVerticalAxis("PlayerJoystick");
        CheckBridge();
    }
    private void FixedUpdate() {
        JoystickMovement();
        Rotate();
    }
     protected virtual void JoystickMovement()
    {
        //rb.velocity = new Vector3(horizontal * speed, rb.velocity.y, vertical * speed);
        Vector3 movement = new Vector3(horizontal, 0f, vertical).normalized;
        Vector3 moveDestination = transform.position + speed * Time.deltaTime * movement;
        dir = moveDestination - transform.position;
        dir = dir.normalized;
        rb.velocity = new Vector3(horizontal * speed, rb.velocity.y, vertical * speed);
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
    protected void CheckBridge()
    {
        
        Debug.DrawRay(transform.position + dir + new Vector3(0, 1f, 0f), new Vector3(0,-5f,0)  , Color.red);
        if (Physics.Raycast(transform.position + dir + new Vector3(0, 1f, 0.5f), new Vector3(0, -5f, 0), out RaycastHit hit, 10f, stepLayer))
        {
            
            if(Cache.GetRaycastInedibleBlock(hit).ColorSkin == ColorSkin.None &&  vertical <= 0)
            {
                Cache.GetRaycastCollider(hit).isTrigger = false;
            }
            if(Cache.GetRaycastInedibleBlock(hit).ColorSkin != ColorSkin && PlayerBlock.standingBlock.Count <= 0 && vertical > 0)
            {
                Cache.GetRaycastCollider(hit).isTrigger = false;
            }
            else if(vertical <= 0){
                Cache.GetRaycastCollider(hit).isTrigger = true;
            }
            else if(Cache.GetRaycastInedibleBlock(hit).ColorSkin != ColorSkin && PlayerBlock.standingBlock.Count >= 0  && vertical >= 0){
                Cache.GetRaycastCollider(hit).isTrigger = true;
            }
            
        }
    }

     public void ChangeColor(ColorSkin colorType)
    {
        ColorSkin = colorType;
        meshRenderer.material = colorData.GetMaterial(colorType);
    }
    public bool GetMove(){
        return horizontal != 0 || vertical != 0; 
    }
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag(Constants.TAG_State) && other.transform.GetComponent<State>() != this.state){
            this.state = other.transform.GetComponent<State>();
            state.SpawnFirstBrick(ColorSkin);
            state.Door.gameObject.SetActive(true);
        }
    }
    
}
