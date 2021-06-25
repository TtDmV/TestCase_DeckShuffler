using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeckShuffler.Models
{
    public class Card
    {
        public Suit suit;
        public CardNum num;

        public Card(Suit cardSuit, CardNum cardNum)
        {
        suit = cardSuit;
        num = cardNum;
        }
        public string GetCardName()
        {
            string cardName = num + " of " + suit;
            return cardName;
        }
    }

   

    public enum Suit
    {
        Spades,
        Hearts,
        Diamonds,
        Clubs
    }

    public enum CardNum
    {
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King,
        Ace
    }    
}