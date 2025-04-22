using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEventManager : MonoBehaviour
{
    public static event Action OnPlayerAttack;
    public delegate  void OnPlayerHit(int damage);
    public delegate void OnplayerHeal(int heal);
    public static event OnPlayerHit onPlayerHit;
    public static event OnplayerHeal onPlayerHeal;
    public static event Action OnCardUse;
    public static int curHealth;


    public static void Attack(){
        OnPlayerAttack?.Invoke();
    }

    public static void PlayerLifeChanged(int newHealth){
        int changedLife = newHealth - curHealth;
        Debug.Log(changedLife);
        if(changedLife > 0) onPlayerHeal?.Invoke(changedLife);
        else if(changedLife < 0) onPlayerHit?.Invoke(changedLife);
        curHealth = newHealth;
    }
    public static void CardUse(){
        OnCardUse?.Invoke();
    }
}
