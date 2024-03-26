using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ChardterController2D : MonoBehaviour
{
    [Header("Player Attributes")]
    [SerializeField] float moveSpeed = 5.0f;
    [SerializeField] float SprintMultiplier = 2.0f;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] private Animator _anim;
    private float x;
    private float y;
    private float sprintSpeed;

    Vector2 movement;
    Vector2 lastDirect = Vector2.down;
    void Start()
    {
        _anim.GetComponent<Animation>();
        rb = GetComponent<Rigidbody2D>();
        sprintSpeed = moveSpeed * SprintMultiplier;
    }
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        x = movement.x;
        y = movement.y;
        //Stops player's idle at last key press
        if(Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("S pressed");
            _anim.SetFloat("IdleY",1);
            _anim.SetFloat("IdleX",0);
        }
        if(Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("W pressed");
           _anim.SetFloat("IdleY",-1);
           _anim.SetFloat("IdleX",0);
        }
        if(Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("A pressed");
            _anim.SetFloat("IdleY", 0);
            _anim.SetFloat("IdleX",1);
        }
        if(Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("D pressed");
            _anim.SetFloat("IdleY",0);
            _anim.SetFloat("IdleX",-1);
        }
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            Debug.Log("Left Shift pressed");
            moveSpeed = sprintSpeed;
        }
        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            Debug.Log("Left Shift up");
            moveSpeed = 5.0f;
        }
    }
    //Fires both of the Movement and Animation
    void FixedUpdate()
    {
        PlayerMove();
        PlayerAnimaiton();
    }
    //Moves Player
   public void PlayerMove()
    {
        //Moves player based off of rigidbody
        rb.MovePosition(rb.position +  movement.normalized * moveSpeed * Time.fixedDeltaTime);
    }
    //Plays animation
    public void PlayerAnimaiton()
    {
        _anim.SetFloat("POSX",x);
        _anim.SetFloat("POSY",y);
        if(movement != Vector2.zero)
        {
            _anim.SetBool("PlayerPOSMove",true);
        }
        else
        {
            _anim.SetBool("PlayerPOSMove",false);
        }
    }
}