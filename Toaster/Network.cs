using System;
using System.Collections.Generic;
using System.Text;
using Serilog;
using WatsonTcp;
using System.Linq;
using Newtonsoft.Json;
using Toaster.HileKontrol;

namespace Toaster
{
    class Network
    {
        public static WatsonTcpServer server;

        public static void ServerBaslat()
        {
            Log.Debug("Server Başlatılıyor...");

            server = new WatsonTcpServer("127.0.0.1", 8163);

            server.Events.ServerStarted += ServerBaslatildi;
            server.Events.MessageReceived += MesajGeldi;
            server.Events.ClientConnected += ClientBaglandi;
            server.Events.ClientDisconnected += ClientBaglantisiKesildi;

            server.Start();
        }

        public static void ServerBaslatildi(object sender, EventArgs e)
        {
            Log.Debug("Server {port} portundan dinlemeye açıldı.", 8163);

            AnaKontrol.HileKontrolBaslat();
        }

        public static void HepsineGonder(string mesaj)
        {
            var clientler = server.ListClients();

            foreach (string client in clientler)
            {
                server.Send(client, mesaj);
            }
        }

        public static void MesajGeldi(object sender, MessageReceivedEventArgs e) { }

        public static void ClientBaglandi(object sender, ConnectionEventArgs e) 
        {
            Log.Debug("Bağlandı: {ip}", e.IpPort);
        }

        public static void ClientBaglantisiKesildi(object sender, DisconnectionEventArgs e)
        {
            Log.Debug("Bağlantı Kesildi: {ip}", e.IpPort);
        }
    }
}
