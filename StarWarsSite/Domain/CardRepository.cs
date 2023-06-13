using Microsoft.AspNetCore.Mvc;
using StarWarsSite.Controllers;
using StarWarsSite.Models;

namespace StarWarsSite.Domain
{
    public class CardRepository
    {
        AppDbContext context;

        public CardRepository(AppDbContext _context)
        {
            context = _context;
        }
        public IEnumerable<Card> GetCards()
        {
            return context.Cards.ToList();
        }

        public Card GetCardById(Guid id) {
            return context.Cards.FirstOrDefault(x => x.Id == id);
        }

        public async void AddCard(Card card) {
            context.Cards.Add(card);
            await context.SaveChangesAsync();
        }

        public async void DeleteCard(Card card)
        {
            context.Cards.Remove(card);
            await context.SaveChangesAsync();
        }

    }
}
