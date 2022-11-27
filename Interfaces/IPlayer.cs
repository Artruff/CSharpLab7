using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLab7.Interfaces
{
    interface IPlayer : IGetMassage, ICloneable
    {
        public int healthPoint { get;}
        public int addHealthPoint { set; }
        public int manaPoint { get; }
        public int addManaPoint { set; }
        public int gold { get; }
        public int addGold { set; }
        public Dictionary<String, String> propertys
        {
            get;
        }
        public List<IEffect> effects
        {
            get;
        }
        public List<ICard> collode { get; }
        public List<ICard> hand { get; }
    }
}
