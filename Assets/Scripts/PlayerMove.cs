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
    private Rigidbody2D myRigid;
    void Move()
    {
        anim.SetBool("Moving", true);  
        speed = new Vector2(maxSpeed*xmove, maxSpeed*ymove);
        //speed = new Vector3(maxSpeed*xmove*Time.deltaTime, maxSpeed*ymove*Time.deltaTime);

        if(xmove >0){
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
             //this.GetComponent<SpriteRenderer>().flipX = false;
        }
        else if(xmove < 0) {
           transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
            //this.GetComponent<SpriteRenderer>().flipX = true;
        }

        myRigid.velocity = speed;
        //transform.position += speed; 
    }
    
    public void AttackAnim() {
        anim.SetTrigger("Attack");
    }

    public void GetGuardAnim(){
        anim.SetBool("Guard", true);
    }

    public void OutGuardAnim(){
        anim.SetBool("Guard", false);
    }

    public void UseCardAnim(){
        anim.SetTrigger("UseCard");
    }

    public void DamagedAnim(int damage){
        anim.SetTrigger("Hit");
    }

    private void Awake()
    {
        myRigid = GetComponent<Rigidbody2D>();
        PlayerEventManager.OnPlayerAttack += AttackAnim;
        PlayerEventManager.OnCardUse += UseCardAnim;
        PlayerEventManager.onPlayerHit += DamagedAnim;
    }
    void Update()
    {
        //movement manage
        xmove = Input.GetAxis("Horizontal");
        ymove = Input.GetAxis("Vertical");

        if((xmove !=0 | ymove !=0) && (anim.GetCurrentAnimatorStateInfo(0).IsName("Player_Move")|anim.GetCurrentAnimatorStateInfo(0).IsName("Player_Idle"))) {
            Move();
        }
        else {
            myRigid.velocity = new Vector2(0, 0);
            anim.SetBool("Moving", false);
        }

        //damage manage
        if(Input.GetKeyDown(KeyCode.H)){
            PlayerStatus.GetDamage(20);
            Debug.Log(PlayerStatus.playerHealth);
        }

    
    }

    

}
