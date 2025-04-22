using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour
{
    public Slider healthSlider;
    public Slider energySlider;
    // Start is called before the first frame update
    void Start()
    {
        healthSlider.maxValue = PlayerStatus.playerHealth;
        PlayerEventManager.curHealth = PlayerStatus.playerHealth;
    }

    // Update is called once per frame
    void Update()
    {
        healthSlider.value = PlayerStatus.playerHealth;
        energySlider.value = PlayerStatus.playerEnergy;
    }
}
