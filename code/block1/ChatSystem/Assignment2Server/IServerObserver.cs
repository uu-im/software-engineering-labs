using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment2Server
{
    public interface IServerObserver
    {
        void ClientAppeared(String nickname);
        void ClientDisappeared(String nickname);
        void NewMessage(String nickname, String message);
    }
}
