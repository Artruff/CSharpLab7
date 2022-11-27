using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLab7.GameManager
{
    class GameManager
    {
        private static  GameManager _game;
        public static GameManager game
        {
            get
            {
                if (_game == null)
                    _game = new GameManager();
                return _game;
            }
        }
        private GameManager()
        {
            players = new List<Interfaces.IPlayer>();
            cardInGame = new List<Interfaces.ICard>();
            cemetery = new List<Interfaces.ICard>();
            currentPlayer = null;
        }
        public List<Interfaces.IPlayer> players;
        public List<Interfaces.ICard> cardInGame;
        public List<Interfaces.ICard> cemetery;
        public Interfaces.IPlayer currentPlayer;
        public void NextPlayer()
        {
            if (currentPlayer == null && players.Count > 0)
                currentPlayer = players[0];
            else
            {
                int indexPlayer = players.FindIndex(p => p == currentPlayer);
                indexPlayer++;
                if (indexPlayer == players.Count)
                    currentPlayer = players[0];
                else
                    currentPlayer = players[indexPlayer];
            }
            ApplyEffectsByMoment(null, null, null, Enumerators.MomentsOfEvents.BetweenMove);
        }
        public void EnterCardInGame(Interfaces.ICard card)
        {
            cardInGame.Add(card);
            ApplyEffectsByMoment(card, null, card, Enumerators.MomentsOfEvents.EnterTheGame);
        }
        public void ExitCardFromGame(Interfaces.ICard card)
        {
            cardInGame.Remove(card);
            ApplyEffectsByMoment(card, null, card, Enumerators.MomentsOfEvents.ExitTheGame);
            cemetery.Add(card);
        }
        public void SendMessage(Interfaces.IMessage message)
        {
            ApplyEffectsByMoment(message.sender, null, null, Enumerators.MomentsOfEvents.SendingMessage);
            foreach (Interfaces.ITakeMessage resipient in message.recipients)
                resipient.takeMessage(message);
            ApplyEffectsByMoment(message.sender, null, null, Enumerators.MomentsOfEvents.ReceivingMessage);
        }
        public Interfaces.IPlayer CheckToWin()
        {
            if (players.Count(p => p.healthPoint > 0) > 1)
                return null;
            else
                return players.Find(p => p.healthPoint > 0);
        }
        private void ApplyEffectsByMoment(Interfaces.ICard initiator, Interfaces.IAction action, Interfaces.ITakeMessage ownerMessage, Enumerators.MomentsOfEvents moment)
        {
            List<Interfaces.IHaveEffect> effectsOwner = new List<Interfaces.IHaveEffect>(players);
            effectsOwner.AddRange(cardInGame);
            foreach (Interfaces.IHaveEffect owner in effectsOwner)
                foreach (Interfaces.IEffect effect in owner.effects.Where(e => e.moments.Contains(moment)))
                    effect.GetEffectMethod(moment)(initiator, action, (Interfaces.ITakeMessage)owner);
        }
        public void MakeMove()
        {
            ApplyEffectsByMoment(null, null, currentPlayer, Enumerators.MomentsOfEvents.BeforeMove);
            int i = 0;
            Interfaces.ICard selectedCard;
            List<Interfaces.ITakeMessage> enemyCards = new List<Interfaces.ITakeMessage>();
            if (currentPlayer.hand.Count != 0)
            {
                Console.WriteLine("Выставить карту?");
                string answer = Console.ReadLine();
                if (answer == "1")
                {
                    foreach (Interfaces.ICard card in currentPlayer.hand)
                        Console.WriteLine((i++).ToString() +" "+ card.propertys["Name"]);
                    i = Convert.ToInt32(Console.ReadLine());
                    currentPlayer.hand[i].intoTheGame();
                }
            }

            List<Interfaces.ICard> playerCards = new List<Interfaces.ICard>(cardInGame.Where(c => c.owner == currentPlayer));

            if (cardInGame.Count(c => c.owner == currentPlayer) != 0)
            {
                Console.WriteLine("Выбери кем атаковать");
                i = 0;
                foreach (Interfaces.IHaveAdditionalProperty card in playerCards)
                    Console.WriteLine((i++).ToString() + " " + card.propertys["Name"]);
                i = Convert.ToInt32(Console.ReadLine());
                selectedCard = playerCards[i];


                enemyCards = new List<Interfaces.ITakeMessage>(players.Where(p => p!=currentPlayer));
                enemyCards.AddRange(new List<Interfaces.ITakeMessage>(cardInGame.Where(c => c.owner != currentPlayer)));
                if (enemyCards.Count != 0)
                {
                    Console.WriteLine("Выбери кого атаковать");
                    i = 0;
                    foreach (Interfaces.IHaveAdditionalProperty card in enemyCards)
                        Console.WriteLine((i++).ToString() + " " + card.propertys["Name"]);
                    i = Convert.ToInt32(Console.ReadLine());
                    List<Interfaces.ITakeMessage> enemyCard = new List<Interfaces.ITakeMessage>();
                    enemyCard.Add(enemyCards[i]);

                    Interfaces.IMessage message = selectedCard.createMessage();
                    message.recipients.Add(enemyCard[0]);
                    foreach(Interfaces.IAction action in message.actions)
                        ApplyEffectsByMoment(message.sender, action, currentPlayer, Enumerators.MomentsOfEvents.InMove);
                    SendMessage(message);
                }
            }

            ApplyEffectsByMoment(null, null, currentPlayer, Enumerators.MomentsOfEvents.AfterMove);
            NextPlayer();
        }
    }
}
