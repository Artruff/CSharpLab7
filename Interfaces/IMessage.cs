using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLab7.Interfaces
{
    interface IMessage
    {
        public ICard sender
        {
            get;
        }
        public List<ITakeMessage> recipients
        {
            get;
        }
        public List<IAction> actions
        {
            get;
        }
    }
}
