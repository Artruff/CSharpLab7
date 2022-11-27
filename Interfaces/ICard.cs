using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLab7.Interfaces
{
    interface ICard : IGetMassage
    {
        public int healthPoint { get; set; }
        public int manaPoint { get; set; }
        public int gold { get; set; }
        public Dictionary<String,String> propertys
        {
            get;
        }
        public List<IEffect> effects
        {
            get;
        }
        public List<IAction> actions
        {
            get;
        }
        public void sendMessage();
        public void intoTheGame();
    }
}
