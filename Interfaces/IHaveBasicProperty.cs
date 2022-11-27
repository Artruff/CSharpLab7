using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLab7.Interfaces
{
    interface IHaveBasicProperty
    {
        public int healthPoint { get; }
        public int addHealthPoint { set; }
        public int manaPoint { get; }
        public int addManaPoint { set; }
        public int gold { get; }
        public int addGold { set; }
    }
}
