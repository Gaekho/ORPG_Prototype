using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class GameManager : MonoBehaviour
{
    public int maxHealth = 150;
    public float energySpeed = 3f;

    
    // Start is called before the first frame update
    void Awake()
    {
        PlayerStatus.playerHealth = maxHealth;
        PlayerStatus.playerEnergy = 0f;      
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerStatus.playerEnergy < 3){
            PlayerStatus.playerEnergy += (1/energySpeed)*Time.deltaTime;
        }

    }

    public void QuitGame(){
        #if UNITY_EDITOR
        EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif        
    }
}
