using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLab7.Players
{
    class ClassicPlayer : Interfaces.IPlayer
    {
        private int _healthPoint;
        private int _manaPoint;
        private int _gold;
        private Dictionary<String, String> _propertys;
        private List<Interfaces.IEffect> _effects;
        private List<Interfaces.ICard> _collode;
        private List<Interfaces.ICard> _hand;

        public int healthPoint
        {
            get => _healthPoint;
        }
        public int addHealthPoint
        {
            set => _healthPoint += value;
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
        public Dictionary<String, String> propertys
        {
            get => _propertys;
        }
        public List<Interfaces.IEffect> effects
        {
            get => _effects;
        }
        public List<Interfaces.ICard> hand
        {
            get => _hand;
        }
        public List<Interfaces.ICard> collode
        {
            get => _collode;
        }
        public ClassicPlayer (int gold, int mn, int hp, List<Interfaces.ICard> collode)
        {
            _gold = gold;
            _manaPoint = mn;
            _healthPoint = hp;
            _collode = new List<Interfaces.ICard>(collode);
            _hand = new List<Interfaces.ICard>();
            _effects = new List<Interfaces.IEffect>();
            _propertys = new Dictionary<string, string>();
        }
        public ClassicPlayer (ClassicPlayer player):this(player.gold, player.manaPoint, player.healthPoint, player._collode)
        {
            _hand = new List<Interfaces.ICard>(player._hand);
            _effects = new List<Interfaces.IEffect>(player._effects);
            _propertys = new Dictionary<string, string>(player._propertys);
        }
        public object Clone()
        {
            return new ClassicPlayer(this);
        }
        public void getMessage(Interfaces.IMessage message) 
        {
            foreach (Interfaces.IAction action in message.actions)
            {
                Interfaces.IAction tmp = (Interfaces.IAction)action.Clone();
                foreach (Interfaces.IEffect effect in effects.Where(e => e.moments.Contains(Enumerators.MomentsOfEvents.ReceivingMessage)))
                    effect.applyEffect(message.sender, tmp, message.recipients);
                tmp.DoAction(message.sender, this, (List<Interfaces.IGetMassage>)(message.recipients.Where(r => r!=this)));
            }
        }
    }
}
