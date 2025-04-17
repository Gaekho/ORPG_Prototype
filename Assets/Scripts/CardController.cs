using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;


public class CardController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler, IBeginDragHandler, IEndDragHandler 
{
    private RectTransform rectTransform;
    private Vector2 originalPosition;
    private Canvas canvas;
    private bool isDragging;
    private Vector2 pointerDownPos;
    private float dragThreshold = 20f;
    private Image myImage;
    public DeckManager myDeck;
    public int thisIndex = 0;
    private Card nowCard = new Card();
    private Slider energy;
    public UnityEvent onCardUse;

    private void Start() {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        originalPosition = rectTransform.anchoredPosition;
        isDragging = false;
        myImage = GetComponent<Image>();
        nowCard = myDeck.SetFirstHand(thisIndex);
        Debug.Log(nowCard.name);
        myImage.sprite = Resources.Load<Sprite>("Cards/" + nowCard.name);

        Slider[] sliders = canvas.GetComponentsInChildren<Slider>();
        foreach(Slider slider in sliders){
            if(slider.name == "Energy Slider"){
                energy = slider;
                break;
            }
        }
    }

    //Event Functions
    public void OnPointerDown(PointerEventData data) {
        pointerDownPos = data.position;
        CardSizeBig();
    }

    public void OnPointerUp(PointerEventData data) {    
        float moveDistance = Vector2.Distance(pointerDownPos, data.position);
        if(moveDistance < dragThreshold){
            CardSizeSmall();
        }
        
        isDragging = false;
    }

    public void OnDrag(PointerEventData data) {
        rectTransform.anchoredPosition += data.delta / canvas.scaleFactor;
        //Debug.Log(rectTransform.anchoredPosition);
    }

    public void OnBeginDrag(PointerEventData data) {
        CardSizeSmall();
        isDragging = true;
    }

    public void OnEndDrag(PointerEventData data) {
        float finalY = rectTransform.anchoredPosition.y;
        //Debug.Log(finalY);
        //Debug.Log("RectTransform name: " + rectTransform.name);

        if(finalY >= 150f) {
           UseCard();
        }
        else CardSizeSmall();
    }

    //Own Functions
    private void CardSizeBig() {
        rectTransform.anchoredPosition = new Vector2(0, 50);
        rectTransform.localScale = new Vector3(2, 2);
    }

    private void CardSizeSmall() {
        rectTransform.anchoredPosition = originalPosition;
        rectTransform.localScale = new Vector3(1, 1);
    }

    private void UseCard(){
        if(energy.value >= nowCard.cost){
            energy.value -= nowCard.cost;
            Debug.Log("Use Card");
            rectTransform.anchoredPosition = originalPosition;
            nowCard.UseEffect();
            onCardUse?.Invoke();
        }
        else {
            Debug.Log("Low Energy");
            CardSizeSmall();
        }
    }

    public void SetCard(Card topCard){
        myImage.sprite = Resources.Load<Sprite>("Cards/" + topCard.name);
        Card tempCard = nowCard;
        nowCard = topCard;
        myDeck.ShiftCard(tempCard);
        Debug.Log("Set New Card : " + nowCard.name);
    }
}