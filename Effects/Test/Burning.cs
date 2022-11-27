using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLab7.Effects.Test
{
    class Burning : Interfaces.IEffect
    {
        List<Enumerators.MomentsOfEvents> _moments;
        Dictionary<String, String> _propertys;
        public Dictionary<String, String> propertys
        {
            get => _propertys;
        }
        public List<Enumerators.MomentsOfEvents> moments { get => _moments; }
        public Burning(int power = 1)
        {
            _moments = new List<Enumerators.MomentsOfEvents>();
            _moments.Add(Enumerators.MomentsOfEvents.AfterMove);
            _propertys = new Dictionary<string, string>();
            _propertys.Add("Timer", (3 * power).ToString());
            _propertys.Add("Power", power.ToString());
            _propertys.Add("Element", "Fire");
            _propertys.Add("TypeDamage", "Magic");
            _propertys.Add("TypeEffect", "Negative");
        }
        public Interfaces.IEffect.Effect GetEffectMethod(Enumerators.MomentsOfEvents moment, Interfaces.ITakeMessage owner = null) 
        {
            Interfaces.IEffect.Effect effect;
            if (moment == Enumerators.MomentsOfEvents.AfterMove)
                effect = ToBurning;
            else
                effect = null;
            return effect;
        }
        public Interfaces.IEffect.Effect GetEffectMethod(Interfaces.IAction action = null)
        {
            if (action.propertys.ContainsKey("Element") && action.propertys["Element"] == "Fire")
                propertys["Timer"] = (3 * Convert.ToInt32(propertys["Power"])).ToString();
            return null;
        }
        public object Clone()
        {
            return new Burning(Convert.ToInt32(propertys["Power"]));
        }
        private void ToBurning(Interfaces.ICard sender = null, Interfaces.IAction action = null, Interfaces.ITakeMessage owner = null)
        {
            if (owner is Interfaces.IHaveBasicProperty && Convert.ToInt32(propertys["Timer"]) >0)
                ((Interfaces.IHaveBasicProperty)owner).addHealthPoint=-1* Convert.ToInt32(propertys["Power"]);
            propertys["Timer"] = (Convert.ToInt32(propertys["Timer"]) -1).ToString();
        }
    }
}
