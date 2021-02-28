using Serilog;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Toaster.TrayControl;

namespace Toaster
{
    class Program
    {
        static Mutex mutex = new Mutex(true, "{73E0208E-64A3-40F0-8710-9E0A91D5C766}");
        static void Main(string[] args)
        {
            if (mutex.WaitOne(TimeSpan.Zero, true))
            {
                try
                {
                    if (args == null || args.Length == 0)
                    {
                        MainAsync().GetAwaiter().GetResult();
                    }
                    else
                    {
                        if (args[0] == "-h")
                        {
                            Console.WriteLine("Toaster by @fikret0");
                            Console.WriteLine("https://github.com/fikret0");

                            HakkindaAsync();
                        }
                        else
                        {
                            MainAsync().GetAwaiter().GetResult();
                        }
                    }
                }
                finally
                {
                    mutex.ReleaseMutex();
                }
            }
            else
            {
                MessageBox.Show("Toaster zaten çalışıyor!", "Toaster", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static async Task MainAsync()
        {
            Application.EnableVisualStyles();

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.File($"logs/ToasterLog.txt", rollingInterval: RollingInterval.Day) //DateTime.UtcNow.ToString("dd-MM-yyyy")
                .CreateLogger();

            Log.Debug("Toaster Başlatılıyor...");

            Tray.StartTray();

            Network.ServerBaslat();

            await Task.Delay(-1);
        }

        public static void HakkindaAsync()
        {
            Application.EnableVisualStyles();

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.File($"logs/ToasterLog.txt", rollingInterval: RollingInterval.Day) //DateTime.UtcNow.ToString("dd-MM-yyyy")
                .CreateLogger();

            Log.Debug("Toaster Hakkında Bölümü Başlatılıyor...");

            Hakkinda hakkinda = new Hakkinda();
            hakkinda.ShowDialog();

            Environment.Exit(0);
        }
    }
}
