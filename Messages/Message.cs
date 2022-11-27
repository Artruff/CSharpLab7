using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLab7.Messages
{
    class Message : Interfaces.IMessage
    {
        private Interfaces.ICard _sender;
        private List<Interfaces.IGetMassage> _recipients;
        private List<Interfaces.IAction> _actions;

        Message(Interfaces.ICard sender)
        {
            _sender = sender;
        }
        Message(Interfaces.ICard sender, List<Interfaces.IAction> actions) : this(sender)
        {
            _actions = new List<Interfaces.IAction>(actions);
            _recipients = new List<Interfaces.IGetMassage>();
        }
        Message(Interfaces.ICard sender, List<Interfaces.IAction> actions, List<Interfaces.IGetMassage> recipients) : this(sender, actions)
        {
            _recipients = new List<Interfaces.IGetMassage>(recipients);
        }
        
        public Interfaces.ICard sender
        {
            get => _sender;
        }
        public List<Interfaces.IGetMassage> recipients
        {
            get => _recipients;
        }
        public List<Interfaces.IAction> actions
        {
            get => _actions;
        }
    }
}
