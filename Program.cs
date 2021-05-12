using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;
using System.Threading;
using System.Runtime.InteropServices;
using AutoUpdate;

namespace MeritSupportAid
{
  
    static class Program
    {
        private static readonly String SingleInst = "MeritSupportAid";
        private static BackgroundWorker singleAppComThread = null;
        private static EventWaitHandle threadComEvent = null;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Updater.GitHubRepo = "/Crackhouse2/MeritSupportAid";
            if (Updater.AutoUpdate(args))
            {
                return;
            }
                

            try
            {
                threadComEvent = EventWaitHandle.OpenExisting(SingleInst);
                threadComEvent.Set();
                threadComEvent.Close();
                return; //You're outta here!!!
            }
            catch { /* Carry on*/ }
            //event handle
            threadComEvent = new EventWaitHandle(false, EventResetMode.AutoReset, SingleInst);
            CreateInterAppComThread();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MSA());

            singleAppComThread.CancelAsync();
            while (singleAppComThread.IsBusy)
            Thread.Sleep(50);
            threadComEvent.Close();

        }

        static private void CreateInterAppComThread()
        {
            singleAppComThread = new BackgroundWorker
            {
                WorkerReportsProgress = false,
                WorkerSupportsCancellation = true
            };
            singleAppComThread.DoWork += new DoWorkEventHandler(SingleAppComThread_DoWork);
            singleAppComThread.RunWorkerAsync();
        }

        static private void SingleAppComThread_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            WaitHandle[] waitHandles = new WaitHandle[] { threadComEvent };

            while (!worker.CancellationPending)
            {
                // check every second for a signal.
                if (WaitHandle.WaitAny(waitHandles, 1000) == 0)
                {
                    // The user tried to start another instance. We can't allow that, 
                    // so bring the other instance back into view and enable that one. 
                    // That form is created in another thread, so we need some thread sync magic.
                    if (Application.OpenForms.Count > 0)
                    {
                        Form mainForm = Application.OpenForms[0];
                        mainForm.Invoke(new SetFormVisableDelegate(ThreadFormVisable), mainForm);
                    }
                }
            }
        }
        [DllImport("USER32.DLL")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        private delegate void SetFormVisableDelegate(Form frm);
        static private void ThreadFormVisable(Form frm)
        {
            if (frm != null)
            {
                // display the form and bring to foreground.
                frm.Visible = true;
                frm.WindowState = FormWindowState.Normal;
                frm.Show();
                SetForegroundWindow(frm.Handle);
            }
        }


    }
}
