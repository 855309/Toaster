using System;
using System.Collections.Generic;
using System.Text;

namespace Toaster
{
    class HileMesaji
    {
        public string ProcessAdi { get; set; }
        public string HileAdi { get; set; }
        public int PID { get; set; }
    }

    class HileBilgileri
    {
        public static List<string> uygulamalar = new List<string>();

        public static void UygulamaAyarla()
        {
            uygulamalar.Add("Cheat Engine");
            uygulamalar.Add("Injector");
            uygulamalar.Add("AutoHotkey");
            uygulamalar.Add("ArtMoney");
            uygulamalar.Add("GameConqueror");
            uygulamalar.Add("BitSlicer");
            uygulamalar.Add("iHaxGamez");
            uygulamalar.Add("Squalr");
            uygulamalar.Add("Memory Hacking Software");
            uygulamalar.Add("RAM Cheat");
            uygulamalar.Add("Mem Write");
            uygulamalar.Add("CoSMOS");
            uygulamalar.Add("Cheat Tool Set");
        }
    }
}
