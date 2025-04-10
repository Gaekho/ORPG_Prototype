using System.Collections;
using System.Collections.Generic;
using System.Xml;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Timeline;

public class PlayerMove : MonoBehaviour
{
    public Animator anim;
    public float maxSpeed;
    private Vector3 speed;
    private float xmove;
    private float ymove;

    public enum state { Idle, Attacking, Guarding, Damaged, Moving, UseCard, Dead}

    state curState = state.Idle;

    public FixedJoystick fixedJoystick;

    void Move()
    {
        anim.SetBool("Moving", true);
        speed = new Vector3(maxSpeed*xmove*Time.deltaTime, maxSpeed*ymove*Time.deltaTime);
        if(xmove >0){
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
             //this.GetComponent<SpriteRenderer>().flipX = false;
        }
        else if(xmove < 0) {
           transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
            //this.GetComponent<SpriteRenderer>().flipX = true;
        }
        transform.position += speed;
    }
    
    public void Attack() {
        anim.SetTrigger("Attack");
    }

    public void GetGuard(){
        anim.SetBool("Guard", true);
    }

    public void OutGuard(){
        anim.SetBool("Guard", false);
    }

    public void UseCard(){
        anim.SetTrigger("UseCard");
    }

    public void Damaged(){
        anim.SetTrigger("Hit");
    }

    void Update()
    {
        //movement manage
        xmove = fixedJoystick.Horizontal;
        ymove = fixedJoystick.Vertical;

        if((xmove !=0 | ymove !=0) && (anim.GetCurrentAnimatorStateInfo(0).IsName("Player_Move")|anim.GetCurrentAnimatorStateInfo(0).IsName("Player_Idle"))) {
            Move();
        }
        else anim.SetBool("Moving", false);


        //damage manage
        if(Input.GetKeyDown(KeyCode.H)){
            Damaged();
        }

        //usecard manage
        if(Input.GetKeyDown(KeyCode.C)){
            UseCard();
        }
    }

    

}
