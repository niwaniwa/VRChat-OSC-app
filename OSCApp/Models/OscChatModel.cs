using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Rug.Osc;

namespace OSCApp.Models
{
    public class OscChatModel
    {
        private OscSender oscSender;

        public OscChatModel()
        {
            IPAddress vrchatOscSendAddress = IPAddress.Parse("127.0.0.1");
            int vrchatOscSendPort = 9000;
            oscSender = new OscSender(vrchatOscSendAddress, 0, vrchatOscSendPort);
            oscSender.Connect();
        }

        public void SendMessage(string message)
        {
            OscMessage oscMessage = new OscMessage("/chatbox/input", message, true, true);
            oscSender.Send(oscMessage);
        }

    }
}
