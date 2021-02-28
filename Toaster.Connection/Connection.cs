using Newtonsoft.Json;
using System;
using System.Text;
using WatsonTcp;

namespace Toaster.Connection
{
    public class ToasterConnection
    {
        public HileBulunduHandler HileBulundu;
        public delegate void HileBulunduHandler(object sender, HileBulunduEventArgs args);
        WatsonTcpClient client;
        public ToasterConnection(string Address)
        {
            client = new WatsonTcpClient(Address, 8163);
            client.Events.MessageReceived += MessageReceived;
        }

        public void Open()
        {
            client.Connect();
        }

        private void MessageReceived(object sender, MessageReceivedEventArgs e)
        {
            Hile hileMesaji = JsonConvert.DeserializeObject<Hile>(Encoding.UTF8.GetString(e.Data));

            HileBulunduEventArgs args = new HileBulunduEventArgs(hileMesaji);

            HileBulundu(this, args);
        }
    }
}
