using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLab7.Interfaces
{
    interface IPlayer : ITakeMessage, ICloneable, IHaveBasicProperty, IHaveAdditionalProperty, IHaveEffect
    {
        public List<ICard> collode { get; }
        public List<ICard> hand { get; }
    }
}
