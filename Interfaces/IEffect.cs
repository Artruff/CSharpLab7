using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLab7.Interfaces
{
    interface IEffect
    {
        public Dictionary<String, String> propertys
        {
            get;
        }
        public delegate void Effect(ICard sender = null, IAction action = null, ICard[] recipients = null);
    }
}
