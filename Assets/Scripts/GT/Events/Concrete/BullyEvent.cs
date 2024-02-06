using System;
using GT.Characters;
using GT.Items.Cards;

namespace GT.Events.Concrete
{
    public class BullyEvent : Event
    {
        public BullyEvent(Random rng) : base(rng, RegularDailyThreshold, string.Empty)
        {
        }
        
        public override void Result(Game game)
        {
            Player player = game.GetPlayer();
            // steal all players money
            player.ModifyMoney(-1 * player.GetMoney());
            // steal the player's best card (if they have any)
            Card card5 = new Card(ECardValue._5);
            Card card4 = new Card(ECardValue._4);
            Card card3 = new Card(ECardValue._3);
            Card card2 = new Card(ECardValue._2);
            Card card1 = new Card(ECardValue._1);
            if (player.HasCard(card5))
            {
                player.RemoveCard(card5);
            }
            else if (player.HasCard(card4))
            {
                player.RemoveCard(card4);
            }
            else if (player.HasCard(card3))
            {
                player.RemoveCard(card3);
            }
            else if (player.HasCard(card2))
            {
                player.RemoveCard(card2);
            }
            else if (player.HasCard(card1))
            {
                player.RemoveCard(card1);
            }
        }
    }
}