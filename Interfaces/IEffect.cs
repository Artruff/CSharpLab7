using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLab7.Interfaces
{
    interface IEffect : ICloneable
    {
        public Dictionary<String, String> propertys
        {
            get;
        }
        List<Enumerators.MomentsOfEvents> moments { get;}
        public Effect getEffectMethod(IGetMassage owner = null);
        public delegate void Effect(ICard sender = null, IAction action = null, IGetMassage owner = null);
    }
}
