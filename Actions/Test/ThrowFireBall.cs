using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLab7.Actions.Test
{
    class ThrowFireBall : Interfaces.IAction
    {
        private Dictionary<String, String> _propertys;
        public Dictionary<String, String> propertys
        {
            get => _propertys;
        }
        public ThrowFireBall(int power = 1)
        {
            _propertys = new Dictionary<string, string>();
            _propertys.Add("Power", power.ToString());
            _propertys.Add("Element", "Fire");
            _propertys.Add("TypeDamage", "Magic");
            _propertys.Add("TypeEffect", "Negative");
        }
        public object Clone()
        {
            return new ThrowFireBall(Convert.ToInt32(propertys["Power"]));
        }
        public Interfaces.IAction.Action GetActionMethod(Interfaces.ITakeMessage recipient = null)
        {
            if (recipient != null)
                return new Interfaces.IAction.Action(ToThrowFireBall);
            else
                return null;
        }
        private void ToThrowFireBall(Interfaces.ICard sender = null, Interfaces.ITakeMessage recipient = null, List<Interfaces.ITakeMessage> anotherRecipient = null)
        {
            if (recipient is Interfaces.IHaveBasicProperty)
                ((Interfaces.IHaveBasicProperty)recipient).addHealthPoint = -2 * Convert.ToInt32(propertys["Power"]);
            if (recipient is Interfaces.IHaveEffect)
                ((Interfaces.IHaveEffect)recipient).effects.Add(new Effects.Test.Burning(Convert.ToInt32(propertys["Power"])));
        }
    }
}
