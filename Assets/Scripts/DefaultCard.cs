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
   
   //Quick Draw
    public void OnPointerUp(PointerEventData data){
        Debug.Log("Quick Draw");
        timer.fillAmount = 0;
        gameObject.SetActive(false);
        card.SetActive(true);
        card.GetComponent<CardController>().SetCard(deck.GetTopCard());
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
