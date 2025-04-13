using System.Collections.Generic;

public class QPlayerDeck //this is Queue
{
    public List<int> deckList = new List<int>{0, 1, 2, 3, 4, 5, 6};
    //public int[] deckList = new int[7]{0, 1, 2, 3, 4, 5, 6};

    public Card[] handCard = new Card[3];
    public Card[] deckQ = new Card[4];
    private int _pointer = 0;
    public int cursor {
        set {
            if(value >= 4) _pointer = 0;
            else _pointer = value;
        }
        get {return _pointer;}
    }


    public void SetHand(Card card, int index){
        handCard[index] = card;
        //deckList.RemoveAt(0);
    }
   public void SetDeck(Card card, int index){
        deckQ[index] = card;
   }

   public void ShuffleDeck(List<int> list){
        for (int i = 0; i < list.Count; i++)
        {
            int randIndex = UnityEngine.Random.Range(i, list.Count);
            (list[i], list[randIndex]) = (list[randIndex], list[i]);
        }

   }
}

