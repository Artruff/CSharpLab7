using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLab7.Interfaces
{
    interface IAction : ICloneable
    {
        public Dictionary<String, String> propertys
        {
            get;
        }
        public Action getActiontMethod(IGetMassage recipient = null);
        public Action getActiontMethod(IAction action = null);
        public delegate void Action(ICard sender = null, IGetMassage recipient = null, List<IGetMassage> anotherRecipient = null);
    }
}
