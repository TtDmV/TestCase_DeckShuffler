using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeckShuffler.Models
{
    public class Deck

    {
        public string Name { get; set; }
        internal List<Card> Cards = new List<Card>();
        public List<string> CardNames =  new List<string>();  //Костыль, нужно правильно обработать имена карт и вывести их в морду
        
        public Deck GetDeck()
        {
            this.RefreshCardNamesList();         
            return this;            
        } 
        
        internal void RefreshCardNamesList()
        {
            CardNames.Clear();
            foreach (Card card in this.Cards)
            {
                this.CardNames.Add(card.GetCardName());
            }
        }   

        public void AutoFill52Deck()
        {

            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                foreach (CardNum cardNum in Enum.GetValues(typeof(CardNum)))
                {
                    Card newCard = new Card(suit, cardNum);
                    this.Cards.Add(newCard);
                }
            }
        }

        public Deck Create52Deck(string name)
        {
            Deck deck = new Deck();
            deck.Name = name;
            deck.AutoFill52Deck();
            return deck;
        }
    }

   
}