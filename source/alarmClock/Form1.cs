using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace alarmClock
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon1.Visible = false;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == this.WindowState)
            {
                notifyIcon1.Visible = true;
                this.Hide();
            }
        }

        void alert()
        {
            Console.Beep();
            MessageBox.Show("You have a task to do.", "AlarmClock");
        }

        void checkAlarms()
        {
            string execDir = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

            string alarmFile = execDir + @"\calendar.txt";

            string lastAlarm = "";

            while (true)
            {

                if (!File.Exists(alarmFile)) File.Create(alarmFile).Dispose();

                string hoursAndSeconds = DateTime.Now.ToString("H'h'm"); //4h5
                string dayAndMonth = DateTime.Now.ToString("d.M"); //17.2

                StreamReader paramReader = new StreamReader(alarmFile);
                string line;
                while ((line = paramReader.ReadLine()) != null)
                {
                   
                    if (line.Contains(hoursAndSeconds) && line.Contains(dayAndMonth) && lastAlarm != hoursAndSeconds)
                    {
                        lastAlarm = hoursAndSeconds;
                        Process.Start("explorer.exe", alarmFile);
                        Task.Run(() => alert());
                    }
                }
                paramReader.Close();

                label1.Invoke(new MethodInvoker(delegate
                {
                    label1.Text = dayAndMonth + " " + hoursAndSeconds;
                }));

                Thread.Sleep(1000);
            }
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            Task.Run(() => checkAlarms());
            this.Hide();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
