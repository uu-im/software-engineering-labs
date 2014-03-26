using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment2Server
{
    class ServerStartException : Exception
    {
        public ServerStartException() : base() { }
        public ServerStartException(string message) : base(message) { }
        public ServerStartException(string message, Exception e) : base(message, e) { }
    }
}
