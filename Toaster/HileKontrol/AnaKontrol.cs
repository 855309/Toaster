using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Serilog;
using System.Threading.Tasks;
using System.Diagnostics;
using DiffLib;
using Newtonsoft.Json;

namespace Toaster.HileKontrol
{
    public class AnaKontrol
    {
        public static async void HileKontrolBaslat()
        {
            Log.Debug("Hile Kontrolüne Başlanıyor...");

            HileBilgileri.UygulamaAyarla();

            Log.Information("Periyodik Hile Kontrolü Başladı. Interval: {saniye} saniye", 5);

            while (true)
            {
                await HileKontrolLoop();

                await Task.Delay(5000);
            }
        }

        public static async Task<bool> HileKontrolLoop()
        {
            List<Process> processes = Process.GetProcesses().ToList();

            foreach (Process process in processes)
            {
                if(process.MainWindowHandle != IntPtr.Zero)
                {
                    foreach (string baslikmatch in HileBilgileri.uygulamalar)
                    {
                        if (process.MainWindowTitle.ToLower().Contains(baslikmatch.ToLower()))
                        {
                            HileMesaji hm = new HileMesaji();
                            hm.HileAdi = baslikmatch;
                            hm.ProcessAdi = process.ProcessName;
                            hm.PID = process.Id;

                            Log.Information("Hile Bulundu! Hile Adı: {hileadi} Process Adı: {processadi} PID: {pid}", hm.HileAdi, hm.ProcessAdi, hm.PID);

                            string cikti = JsonConvert.SerializeObject(hm);

                            Network.HepsineGonder(cikti);
                        }
                    }
                }
            }

            return await Task.FromResult(true);
        }
    }
}
