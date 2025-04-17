using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEventManager : MonoBehaviour
{
    public static event Action OnPlayerAttack;
    public  delegate  void OnPlayerHit(float damage);
    public delegate void OnplayerHeal(float heal);
    public static event OnPlayerHit onPlayerHit;
    public static event OnplayerHeal onPlayerHeal;
    public static event Action OnCardUse;
    public float curHealth;


    public void Attack(){
        OnPlayerAttack?.Invoke();
    }

    public void PlayerLifeChanged(float newHealth){
        float changedLife = newHealth - curHealth;
        Debug.Log(changedLife);
        if(changedLife > 0) onPlayerHeal?.Invoke(changedLife);
        else if(changedLife < 0) onPlayerHit?.Invoke(changedLife);
        curHealth = newHealth;
    }
    public void CardUse(){
        OnCardUse?.Invoke();
    }
}
