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
        private List<Card> Cards = new List<Card>(); 
        private List<string> CardNames =  new List<string>(); 
        
        public Deck GetDeck()
        {
            foreach (Card card in this.Cards)
            {
                this.CardNames.Add(card.GetCardName());
            }
            return this;            
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