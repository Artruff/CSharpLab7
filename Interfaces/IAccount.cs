using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLab7.Interfaces
{
    interface IAccount
    {
        public string login { get; }
        public List<Interfaces.ICard> collection { get; }
        public List<List<Interfaces.ICard>> сollodes { get; }
    }
}
