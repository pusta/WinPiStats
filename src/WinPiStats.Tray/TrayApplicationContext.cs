using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;
using System.Windows.Forms;
using System.IO;



namespace WinPiStats.Tray
{
    class TrayApplicationContext : ApplicationContext
    {

        private readonly string _autostartKey = "WinPiStats";
        private NotifyIcon _trayIcon;
        private ToolStripMenuItem menuExitItem;
        private ToolStripMenuItem menuSettingsItem;
        private ToolStripMenuItem menuAutoStart;

        public TrayApplicationContext()
        {



        }

        private void CreateTrayIcon()

        {

            ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
            menuSettingsItem = new ToolStripMenuItem("Settings", null, showSettings);
            menuExitItem = new ToolStripMenuItem("Exit", null, Exit);
            menuAutoStart = new ToolStripMenuItem("AutoStart", null, AutoStartToggle);
            contextMenuStrip.Items.Add(menuAutoStart);
            contextMenuStrip.Items.Add(menuSettingsItem);
            contextMenuStrip.Items.Add(menuExitItem);
            contextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(cms_opening);







            _trayIcon = new NotifyIcon()
            {
                Visible = true,
                ContextMenuStrip = contextMenuStrip,
                //Icon = Resources.WPSIcon,
                Text = "WinPiStats",




            };
            _trayIcon.DoubleClick += new System.EventHandler(_trayIcon_Click);


        }

        private void _trayIcon_Click(object sender, System.EventArgs e)
        {
            //var displayStats = new DisplayStats();
            //displayStats.Show();



        }

        private void showSettings(object sender, EventArgs e)
        {
            //menuSettingsItem.Checked = !menuSettingsItem.Checked;

            //var settingsForm = new Settings();
            //settingsForm.Show();


        }

        private void Exit(object sender, EventArgs e)
        {

            _trayIcon.Visible = false;
            Application.Exit();
        }

        private void cms_opening(object sender, EventArgs e)
        {
            /* bool runningAsService = _runType == RunType.Service;
             bool exeRunning = false;
             if (runningAsService)
                 _serviceController.Refresh();
             else
                 exeRunning = Process.GetProcessesByName("jellyfin").Length > 0;
             bool running = (!runningAsService && exeRunning) || (runningAsService && _serviceController.Status == ServiceControllerStatus.Running);
             bool stopped = (!runningAsService && !exeRunning) || (runningAsService && _serviceController.Status == ServiceControllerStatus.Stopped);
             _menuItemStart.Enabled = stopped;
             _menuItemStop.Enabled = running;
             _menuItemOpen.Enabled = running;*/
            menuAutoStart.Checked = AutoStart;
        }


        private void AutoStartToggle(object sender, EventArgs e)
        {
            AutoStart = !AutoStart;
        }

        private bool AutoStart
        {
            get
            {
                using RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                return key.GetValue(_autostartKey) != null;
            }
            set
            {
                using RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                if (value && key.GetValue(_autostartKey) == null)
                {
                    key.SetValue(_autostartKey, Path.ChangeExtension(Application.ExecutablePath, "exe"));
                }
                else if (!value && key.GetValue(_autostartKey) != null)
                {
                    key.DeleteValue(_autostartKey);
                }
            }


        }
    }
}
