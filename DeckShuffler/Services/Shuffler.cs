using DeckShuffler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeckShuffler.Services
{
    public class Shuffler
    {

        internal Deck Shuffle(Deck deck, string method)
        {
            switch(method)
            {
                case "Simple":
                    deck.Cards = SimpleShuffle(deck.Cards);
                    break;
                case "Manual":
                    deck.Cards = ManualShuffle(deck.Cards);
                    break;
            }
            deck.RefreshCardNamesList();
            return deck;
        }

        private List<Card> SimpleShuffle(List<Card> cards)
        {
            Random rand = new Random();            
            for (int i = cards.Count() - 1; i >= 1; i-- )
            {
                int j = rand.Next(i + 1);

                Card tmp = cards[j];
                cards[j] = cards[i];
                cards[i] = tmp;               
            }
            return cards;
        }

        private List<Card> ManualShuffle(List<Card> cards)
        {
            List<Card> shuffledDeck = cards;
            Random rand = new Random();
            for (int i = 1; i <= 200; i++)
            {
                int pm = (int)Math.Floor((decimal)(cards.Count / 8));
                int rndSplitCount = ((int)Math.Floor((decimal)(cards.Count / 2))  + rand.Next(- pm, pm)); 
                List<Card> tmp1 = shuffledDeck.Take(rndSplitCount).ToList<Card>();
                List<Card> tmp2 = shuffledDeck.Skip(rndSplitCount).Take(cards.Count() - rndSplitCount).ToList<Card>();
                shuffledDeck.Clear();
                shuffledDeck.AddRange(tmp2);
                shuffledDeck.AddRange(tmp1);
            }
            return shuffledDeck;

        }
    }

}