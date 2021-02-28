using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Serilog;

namespace Toaster.TrayControl
{
    public class Tray
    {
        public static NotifyIcon trayIcon = new NotifyIcon();
        public static void StartTray()
        {
            Log.Debug("System Tray'e Ekleniyor...");
            trayIcon.Icon = Toaster.Properties.Resources.ToasterLogo;

            trayIcon.Text = "Toaster Hile Koruma Sistemi";
            trayIcon.Visible = true;
        }
    }
}
