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
        public Action DoAction(ICard sender = null, List<IGetMassage> recipients = null);
        public delegate void Action(ICard sender = null, List<IGetMassage> recipients = null);
    }
}
