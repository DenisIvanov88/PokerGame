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
            HandAndBoard = new List<Card>();
        }

        public string Name { get; private set; }
        public List<Card> Hand { get; private set; }
        public uint Balance { get; set; }
        public uint CurrentBid { get; set; }
        public bool NotFolded { get; set; }
        public BestHand BestHand { get; set; }
        public List<Card> HandAndBoard { get; set; }

        public void AddCards(params Card[] cards)
        {
            foreach(var c in cards)
            {
                Hand.Add(c);
            }
        }
        public virtual void DoAction()
        {

        }
        public void Call()
        {
            Balance -= BetController.GetHighestBet() - CurrentBid;
            CurrentBid = BetController.GetHighestBet();
            Console.WriteLine($"{Name} called");
        }
        public void Raise(uint raiseValue)
        {
            Balance -= BetController.GetHighestBet() + raiseValue - CurrentBid;
            CurrentBid = BetController.GetHighestBet() + raiseValue;
            Console.WriteLine($"{Name} raised {raiseValue}");
        }
        public void Fold()
        {
            NotFolded = false;
        }
        public void ResetPlayer()
        {
            this.Hand = new List<Card>();
            this.HandAndBoard = new List<Card>();
            this.CurrentBid = 0;
            this.NotFolded = true;
            this.BestHand.BestCards = new List<Card>();
            this.BestHand.Value = 0;
        }

        public override string ToString()
        {
            return $"Balance: {Balance}, Current bid: {CurrentBid}";
        }
    }
}
