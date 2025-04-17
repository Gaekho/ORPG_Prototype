using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DefaultCard : MonoBehaviour, IPointerUpHandler
{
    public GameObject card;
    public DeckManager deck;
    public Image timer;
    public float drawCoolTime;

    private Canvas canvas;
    private Slider energy;

    public void Start()
    {
        canvas = GetComponentInParent<Canvas>();
        Slider[] sliders = canvas.GetComponentsInChildren<Slider>();
        foreach(Slider slider in sliders){
            if(slider.name == "Energy Slider"){
                energy = slider;
                break;
            }
        }
    }

    //Quick Draw
    public void OnPointerUp(PointerEventData data){
        if(energy.value >= 1){
            energy.value -= 1;
            Debug.Log("Quick Draw");
            timer.fillAmount = 0;
            gameObject.SetActive(false);
            card.SetActive(true);
            card.GetComponent<CardController>().SetCard(deck.GetTopCard());
        }
        else {
            Debug.Log("Low Energy");
        }
    }
    //Cooled Draw
    void Update()
    {
        timer.fillAmount += (1/drawCoolTime)*Time.deltaTime;
        
        if(timer.fillAmount >= 1){
            timer.fillAmount = 0;
            gameObject.SetActive(false);
            card.SetActive(true);
            card.GetComponent<CardController>().SetCard(deck.GetTopCard());

        }
    }
}
