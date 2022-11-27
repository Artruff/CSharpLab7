using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLab7.Interfaces
{
    interface IHaveEffect
    {
        public List<IEffect> effects
        {
            get;
        }
    }
}
