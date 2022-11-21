﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLab7.Interfaces
{
    interface IAction
    {
        public Dictionary<String, String> propertys
        {
            get;
        }
        public delegate void Action(ICard sender = null, ICard[] recipients = null);
    }
}