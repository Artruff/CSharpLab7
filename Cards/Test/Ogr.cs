using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLab7.Cards.Test
{
    class Ogr : Interfaces.ICard
    {
        private Interfaces.IPlayer _owner;
        private int _healthPoint;
        private int _manaPoint;
        private int _gold;
        private Dictionary<String, String> _propertys;
        private List<Interfaces.IEffect> _effects;
        private List<Interfaces.IAction> _actions;
        public Interfaces.IPlayer owner { get => _owner; }
        public Dictionary<String, String> propertys
        {
            get => _propertys;
        }
        public List<Interfaces.IAction> actions
        {
            get => _actions;
        }

        public int healthPoint
        {
            get => _healthPoint;
        }
        public int addHealthPoint
        {
            set 
            {
                _healthPoint += value;
                if (_healthPoint <= 0)
                    exitTheGame();
            }
        }
        public int manaPoint
        {
            get => _manaPoint;
        }
        public int addManaPoint
        {
            set => _manaPoint += value;
        }
        public int gold
        {
            get => _gold;
        }
        public int addGold
        {
            set => _gold += value;
        }
        public List<Interfaces.IEffect> effects
        {
            get => _effects;
        }
        public Ogr(Interfaces.IPlayer player, int power)
        {
            _owner = player;
            _actions = new List<Interfaces.IAction>();
            actions.Add(new Actions.Test.Hit(power));
            _gold = 5;
            _manaPoint = 0;
            _healthPoint = 10;
            _propertys = new Dictionary<string, string>();
            _effects = new List<Interfaces.IEffect>();
            _propertys.Add("Power", power.ToString());
            _propertys.Add("Name", "Ogr");
            _propertys.Add("Class", "Fighter");
            _propertys.Add("Species", "Ogr");
        }
        public Ogr(Ogr ogr)
        {
            _owner = ogr.owner;
            _gold = ogr._gold;
            _manaPoint = ogr._manaPoint;
            _healthPoint = ogr._healthPoint;
            _propertys = new Dictionary<string, string>(ogr._propertys);
            _effects = new List<Interfaces.IEffect>(ogr._effects);
        }
        public object Clone()
        {
            return new Ogr(this);
        }
        public Interfaces.IMessage createMessage() 
        {
            return new Messages.Message(this, actions);
        }
        public void takeMessage(Interfaces.IMessage message)
        {
            foreach (Interfaces.IAction action in message.actions)
            {
                Interfaces.IAction tmp = (Interfaces.IAction)action.Clone();
                foreach (Interfaces.IEffect effect in effects.Where(e => e.moments.Contains(Enumerators.MomentsOfEvents.ReceivingMessage)))
                    effect.GetEffectMethod(action)(message.sender, tmp, this);
                List<Interfaces.ITakeMessage> anotherRecipient = new List<Interfaces.ITakeMessage>(message.recipients);
                anotherRecipient.Remove(this);
                tmp.GetActionMethod(message.sender)(message.sender, this, anotherRecipient);
            }
        }
        public void intoTheGame() 
        {
            owner.addGold = -gold;
            owner.hand.Remove(this);
            GameManager.GameManager.game.EnterCardInGame(this);
        }
        public void exitTheGame() 
        {
            GameManager.GameManager.game.ExitCardFromGame(this);
        }
    }
}
