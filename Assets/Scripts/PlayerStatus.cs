using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerStatus {
    //private static int PlayerHealth;
    public static int playerHealth;
    public static float playerEnergy;
    public static int playerATK;
    public static int playerDEF;


    public static void GetDamage(int damage){
        playerHealth -= damage;
    }

    public static void GetHeal(int heal){
        playerHealth += heal;
    }

    public static void GetEnergy(float energy){
        playerEnergy += energy;
    }
}
