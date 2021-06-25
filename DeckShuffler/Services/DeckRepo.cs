using DeckShuffler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeckShuffler.Services
{
    public class DeckRepo
    {
        private const string CacheKey = "DeckStore";
        public Deck[] GetAllDecks()
        {
            var ctx = HttpContext.Current;

            if (ctx != null)
            {
                return (Deck[])ctx.Cache[CacheKey];
            }

            return new Deck[]
            {
                new Deck { Name = "Placeholder" }
            };
        }

        public Deck GetDeckByName(string deckName)
        {
            var ctx = HttpContext.Current;

            if (ctx != null)
            {
                var deckByName = ((Deck[])ctx.Cache[CacheKey]).Where(d => d.Name == deckName).FirstOrDefault(); // не делаем проверку на единственное значение, проверим на этапе создания
                if (deckByName != null) return deckByName.GetDeck(); 
            }

            Console.WriteLine("Deck not found");
            return null;
            
        }

        public DeckRepo()
        {
            var ctx = HttpContext.Current;

            if (ctx != null)
            {
                if (ctx.Cache[CacheKey] == null)
                {
                    var decks = new Deck[] 
                    {
                        new Deck { Name = "Deck1" }
                    };
                    decks[0].AutoFill52Deck();
                    ctx.Cache[CacheKey] = decks;
                }
            }
        }

        public bool SaveDeck(Deck deck) //проверку по имени
        {
            var ctx = HttpContext.Current;

            if (ctx != null)
            {
                try
                {
                    var currentData = ((Deck[])ctx.Cache[CacheKey]).ToList();
                    if (currentData.Find(d => d.Name == deck.Name) == null)
                    {
                        deck.AutoFill52Deck(); 
                        currentData.Add(deck);
                        ctx.Cache[CacheKey] = currentData.ToArray();

                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Cannot create. Deck with this name already exists");
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return false;
                }
            }

            return false;
        }
     
    }
}