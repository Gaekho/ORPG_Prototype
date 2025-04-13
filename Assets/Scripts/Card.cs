using System;
using Unity.VisualScripting;

public class Card 
{
   public int id;
   public string name;
   public int cost;
   public string type;

   public Action CardEffect;
   public void UseEffect() {CardEffect?.Invoke();}
}

public class AttackCard : Card 
{
    public float damage;

    public AttackCard(int _id, string _name, int _cost, string _type, float _damage, Action _effect){
        this.id = _id;
        this.name = _name;
        this.cost = _cost;
        this.type = _type;
        this.damage = _damage;
        this.CardEffect = _effect;
    }//생성자
}

public class BehaviourCard : Card
{
    public BehaviourCard(int _id, string _name, int _cost, string _type, Action _effect){
        this.id = _id;
        this.name = _name;
        this.cost = _cost;
        this.type = _type;
        this.CardEffect = _effect;
    }//생성자
}

public class SupportCard : Card
{
    public SupportCard(int _id, string _name, int _cost, string _type, Action _effect){
        this.id = _id;
        this.name = _name;
        this.cost = _cost;
        this.type = _type;
        this.CardEffect = _effect;
    }//생성자
}
