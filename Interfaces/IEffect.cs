using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLab7.Interfaces
{
    interface IEffect : ICloneable, IHaveAdditionalProperty
    {
        List<Enumerators.MomentsOfEvents> moments { get;}
        public Effect GetEffectMethod(Enumerators.MomentsOfEvents moment, ITakeMessage owner = null);
        public Effect GetEffectMethod(IAction action = null);
        public delegate void Effect(ICard sender = null, IAction action = null, ITakeMessage owner = null);
    }
}
