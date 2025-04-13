using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.PlayerLoop;
using Unity.VisualScripting;
public class DeckManager : MonoBehaviour
{
    public QPlayerDeck qPlayerDeck = new QPlayerDeck();
    public CardList List = new CardList();


    void Awake() //make a Deck in first Step, shuffle and Draw 3 cards.
    {   
        //Shuffle DeckList
        qPlayerDeck.ShuffleDeck(qPlayerDeck.deckList);
        
        //Set Hand Array 
        for(int i=0; i<3; i++){
            foreach(Card _card in List.cardList){
                if(_card.id == qPlayerDeck.deckList[i]){ 
                    qPlayerDeck.SetHand(_card, i);
                }
            }
        }

        //Set Deck Queue
        for(int i=0; i < 4; i++){
            
            foreach(Card _card in List.cardList){
                if(_card.id == qPlayerDeck.deckList[i+3]){
                    qPlayerDeck.SetDeck(_card, i);
                }
            }
            
            //qPlayerDeck.SetDeck(List.cardList[i], i);
        }
        
    }

    void Shuffle(){

    }

    public Card SetFirstHand(int i){
        return qPlayerDeck.handCard[i];
    }
    public Card  GetTopCard(){
        return qPlayerDeck.deckQ[qPlayerDeck.cursor];
    }

    public void ShiftCard(Card card){
        qPlayerDeck.deckQ[qPlayerDeck.cursor] = card;
        qPlayerDeck.cursor++;
    }
}

