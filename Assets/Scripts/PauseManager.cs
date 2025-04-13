using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
   public static bool IsPaused => Time.timeScale == 0f;

   public static void Pause(){
    Time.timeScale = 0f;
    Debug.Log("Paused");
   }

   public static void Resume(){
    Time.timeScale = 1f;
    Debug.Log("Resumed");
   }

   public static void Toggle(){
    if(IsPaused) Resume();
    else Pause();
   }
}
