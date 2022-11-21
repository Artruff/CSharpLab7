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
        private List<Interfaces.ICard> _recipients;
        private List<Interfaces.IAction> _actions;

        Message(Interfaces.ICard sender)
        {
            _sender = sender;
        }

    }
}
