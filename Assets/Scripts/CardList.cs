using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardList 
{
    public List<Card> cardList = new List<Card>();

    public CardList(){
        LoadCards();
    }
    public void LoadCards(){
        
        //CardList.Add(new CardType( _id, _name, _cost, _type, (_damage), ()=> { effect }))
        cardList.Add(new AttackCard(0, "분노", 1, "공격", 10f, () => {Debug.Log("분노 사용");}));
        cardList.Add(new AttackCard(1, "난폭한 타격", 2, "공격", 15f, () => {Debug.Log("난폭한 타격 사용");}));
        cardList.Add(new AttackCard(2, "대검", 3, "공격", 30f, () => {Debug.Log("대검 사용");}));
        cardList.Add(new BehaviourCard(3, "무장 해제", 1, "행동", ()=> {Debug.Log("무장 해제 사용");}));
        cardList.Add(new BehaviourCard(4, "한계 돌파", 1, "행동", ()=> {Debug.Log("한계 돌파 사용");}));
        cardList.Add(new SupportCard(5, "붕대 감기", 0, "보조", ()=> {Debug.Log("붕대 감기 사용");}));
        cardList.Add(new SupportCard(6, "계몽", 1, "보조", ()=> {Debug.Log("계몽 사용");}));
        //...
        
    }
}
