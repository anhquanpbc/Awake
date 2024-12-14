using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Forms;
using ContextMenu = System.Windows.Forms.ContextMenu;

namespace Awake
{
    public partial class MainWindow : Window
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern uint SetThreadExecutionState(uint esFlags);

        const uint ES_CONTINUOUS = 0x80000000;
        const uint ES_SYSTEM_REQUIRED = 0x00000001;
        const uint ES_DISPLAY_REQUIRED = 0x00000002;

        private NotifyIcon _notifyIcon;
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
            this.WindowStartupLocation = WindowStartupLocation.Manual;
            this.Left = SystemParameters.WorkArea.Width - this.Width;
            this.Top = SystemParameters.WorkArea.Height - this.Height;

            InitializeNotifyIcon();
            HideWindow();
        }

        private void InitializeNotifyIcon()
        {
            _notifyIcon = new NotifyIcon
            {
                Icon = System.Drawing.Icon.ExtractAssociatedIcon(System.Windows.Forms.Application.ExecutablePath), // Make sure you have an icon file in your project
                Visible = true,
                Text = "Awake"
            };
            _notifyIcon.DoubleClick += (s, e) => ShowWindow();
            var contextMenu = new ContextMenu();
            contextMenu.MenuItems.Add("Show", (s, e) => ShowWindow());
            contextMenu.MenuItems.Add("Exit", (s, e) => Close());
            _notifyIcon.ContextMenu = contextMenu;
        }

        private void ShowWindow()
        {
            this.Show();
            this.WindowState = WindowState.Normal;
            this.Activate();
        }

        private void HideWindow()
        {
            this.Hide();
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            btnStart_Click(null, null);
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            SetThreadExecutionState(ES_CONTINUOUS | ES_SYSTEM_REQUIRED | ES_DISPLAY_REQUIRED);
            TbStatus.Text = "System will stay awake ✅";
            TbStatus.Foreground = System.Windows.Media.Brushes.Green;
            btnStart.Style = (Style)FindResource("BtnInactive");
            btnStart.IsEnabled = false;
            btnStop.Style = (Style)FindResource("BtnActive");
            btnStop.IsEnabled = true;
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            SetThreadExecutionState(ES_CONTINUOUS);
            TbStatus.Text = "System will sleep ❎";
            TbStatus.Foreground = System.Windows.Media.Brushes.Gray;
            btnStart.Style = (Style)FindResource("BtnActive");
            btnStart.IsEnabled = true;
            btnStop.Style = (Style)FindResource("BtnInactive");
            btnStop.IsEnabled = false;
        }
        protected override void OnClosed(EventArgs e)
        {
            SetThreadExecutionState(ES_CONTINUOUS); // Reset the execution state
            base.OnClosed(e);
        }

        protected override void OnStateChanged(EventArgs e)
        {
            if (WindowState == WindowState.Minimized)
            {
                HideWindow();
            }
            base.OnStateChanged(e);
        }
    }
}
