using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLab7.Interfaces
{
    interface IAction : ICloneable, IHaveAdditionalProperty
    {
        public Action GetActionMethod(ITakeMessage recipient = null);
        public delegate void Action(ICard sender = null, ITakeMessage recipient = null, List<ITakeMessage> anotherRecipient = null);
    }
}
