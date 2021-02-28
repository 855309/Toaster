using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Toaster.Connection;

namespace Test.Connection
{
    class Program
    {
        static void Main(string[] args)
            => Program.MainAsync().GetAwaiter().GetResult();

        public static async Task MainAsync()
        {
            ToasterConnection conn = new ToasterConnection("127.0.0.1");
            conn.Open();

            conn.HileBulundu += hilebulundu;

            await Task.Delay(-1);
        }

        static void hilebulundu(object sender, HileBulunduEventArgs e)
        {
            Hile bulunan = e.Hile;

            Console.WriteLine($"Ad: {bulunan.HileAdi} Process Adı: {bulunan.ProcessAdi} PID: {bulunan.PID}");

            //Process.GetProcessById(bulunan.PID).Kill();
        }
    }
}
