using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class GameManager : MonoBehaviour
{
    public float maxHealth = 300f;
    public float energySpeed = 3f;
    public Slider healthSlider;
    public Slider energySlider;

    void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        healthSlider.maxValue = maxHealth;
        healthSlider.value = maxHealth;
        energySlider.value = 0f;      
    }

    // Update is called once per frame
    void Update()
    {
        if(energySlider.value < 3){
            energySlider.value += (1/energySpeed)*Time.deltaTime;
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
