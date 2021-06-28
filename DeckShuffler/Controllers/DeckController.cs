using DeckShuffler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DeckShuffler.Services;

namespace DeckShuffler.Controllers
{
    public class DeckController : ApiController
    {
        private DeckRepo deckRepo;

        public DeckController()
        {
            this.deckRepo = new DeckRepo();
        }
        [HttpGet]
        public Deck[] Get()
        {
            return deckRepo.GetAllDecks();
        }

        //public Deck Get(string name)
        //{
        //    return deckRepo.GetDeckByName(name);
        //}
        [HttpGet]
        public List<string> Get(string name) //Не всю колоду а только список карт из за сложностей с пониманием вывода информации на морду
        {
            return deckRepo.GetDeckCompositionByName(name);
        }

        [HttpGet]
        public HttpResponseMessage Get(string name, string method)
        {
            var response = new HttpResponseMessage();
            if (this.deckRepo.ShuffleDeck(name, method))
            {
                response = Request.CreateResponse(System.Net.HttpStatusCode.OK);
            }
            else
            {
                response = Request.CreateResponse(System.Net.HttpStatusCode.Conflict);
            }
            return response;
        }

        [HttpPost]
        public HttpResponseMessage Post(Deck deck)
        {
            var response = new HttpResponseMessage();
            if (this.deckRepo.SaveDeck(deck))
                response = Request.CreateResponse<Deck>(System.Net.HttpStatusCode.Created, deck);
            else
                response = Request.CreateResponse<Deck>(System.Net.HttpStatusCode.Conflict, deck);

            return response;
        }

        [HttpDelete]
        public IHttpActionResult Delete(string name)
        {
            if (this.deckRepo.DeleteDeck(name))
                return Ok();
            else return BadRequest("Deck is not found");
        }

    }
}
