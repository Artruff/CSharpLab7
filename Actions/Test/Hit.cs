using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLab7.Actions.Test
{
    class Hit : Interfaces.IAction
    {
        private Dictionary<String, String> _propertys;
        public Dictionary<String, String> propertys
        {
            get => _propertys;
        }
        public Hit(int power = 1)
        {
            _propertys = new Dictionary<string, string>();
            _propertys.Add("Power", power.ToString());
            _propertys.Add("TypeDamage", "Physical");
        }
        public object Clone()
        {
            return new Hit(Convert.ToInt32(propertys["Power"]));
        }
        public Interfaces.IAction.Action GetActionMethod(Interfaces.ITakeMessage recipient = null)
        {
            if (recipient != null)
                return new Interfaces.IAction.Action(ToHit);
            else
                return null;
        }
        private void ToHit(Interfaces.ICard sender = null, Interfaces.ITakeMessage recipient = null, List<Interfaces.ITakeMessage> anotherRecipient = null)
        {
            if (recipient is Interfaces.IHaveBasicProperty)
                ((Interfaces.IHaveBasicProperty)recipient).addHealthPoint = -1 * Convert.ToInt32(propertys["Power"]);
        }
    }
}
