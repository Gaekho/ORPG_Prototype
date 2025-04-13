using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    private BoxCollider2D myWeapon;
    void Awake()
    {
        myWeapon = GetComponent<BoxCollider2D>();
        Debug.Log(myWeapon.name);
        myWeapon.enabled =false;
    }

       private void OnTriggerEnter2D(Collider2D collider){
        if(collider.tag == "Enemy"){
            Debug.Log("Attack Enemy");
            //적 콜라이더의 함수를 발동시키면 되니까, 의외로 쉬울듯? 
        }
    }
}
