using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLab7.Interfaces
{
    interface ICard : ITakeMessage, ICloneable, IHaveBasicProperty, IHaveAdditionalProperty, IHaveEffect
    {
        public IPlayer owner { get; }
        public List<IAction> actions
        {
            get;
        }
        public IMessage createMessage();
        public void intoTheGame();
        public void exitTheGame();
    }
}
