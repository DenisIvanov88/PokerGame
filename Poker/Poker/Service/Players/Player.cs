using Poker.Service.Cards;
using Poker.Service.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Service
{
    public abstract class Player
    {
        protected Player(string name, uint initialBalance)
        {
            this.Hand = new List<Card>();
            this.Name = name;
            this.Balance = initialBalance;
            this.NotFolded = true;
            BestHand = new BestHand();
            HandAndBoard = new HandAndBoard();
        }

        public string Name { get; private set; }
        public List<Card> Hand { get; private set; }
        public uint Balance { get; set; }
        public uint CurrentBid { get; set; }
        public bool NotFolded { get; set; }
        public BestHand BestHand { get; set; }
        public HandAndBoard HandAndBoard { get; set; }

        public void AddCards(params Card[] cards)
        {
            foreach(var c in cards)
            {
                Hand.Add(c);
            }
        }

        public void Call()
        {
            Balance -= BetController.GetHighestBet() - CurrentBid;
            CurrentBid = BetController.GetHighestBet();
        }
        public void Raise(uint raiseValue)
        {
            Balance -= BetController.GetHighestBet() + raiseValue - CurrentBid;
            CurrentBid = BetController.GetHighestBet() + raiseValue;
        }
        public void Fold()
        {
            CurrentBid = 0;
            NotFolded = false;
        }

        public override string ToString()
        {
            return $"Balance: {Balance}, Current bid: {CurrentBid}";
        }
    }
}
