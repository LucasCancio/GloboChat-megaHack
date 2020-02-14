using System;
using System.Collections.Generic;
using System.Text;

namespace GloboChat.Apresentacao.Aplicativo.EventHandlers
{
    public class MessageEventArgs
    {
        public MessageEventArgs(string message, string user)
        {
            Message = message;
            User = user;
        }

        public string Message { get; }
        public string User { get; }
    }
}
