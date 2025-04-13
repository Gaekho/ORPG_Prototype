using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEventManager : MonoBehaviour
{
    public static event Action OnPlayerAttack;
    public static event Action OnPlayerHit;

    public static event Action OnCardUse;


    public void Attack(){
        OnPlayerAttack?.Invoke();
    }

    public void Hitted(){
        OnPlayerHit?.Invoke();        
    }

    public void CardUse(){
        OnCardUse?.Invoke();
    }
}
