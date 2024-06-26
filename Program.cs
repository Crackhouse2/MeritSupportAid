﻿using AutoUpdate;
using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace MeritSupportAid
{

    static class Program
    {
        private static readonly String SingleInst = "MeritSupportAid";
        private static BackgroundWorker singleAppComThread = null;
        private static EventWaitHandle threadComEvent = null;

        /// <summary>
        /// The main entry point for the application.
        /// Contains checks for online resources
        /// Patches to update
        /// Checks to ensure no additional instances are open
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            //Build App Data path and using Environment.Expand...
            string path = @"%appdata%\MSA\";
            path = Environment.ExpandEnvironmentVariables(path);
            string fullpath = path + "TBRes.crk.config";

            //Check if the file already exists in appdata, if not then download
            if (!File.Exists(fullpath))
            {
                //Create folder & web downloader and pull file to path
                Directory.CreateDirectory(path);
                WebClient ResourceDownloader = new WebClient();
                ResourceDownloader.DownloadFile("http://www.meritsoftware.co.uk/YearEnd2021_Config_vals.csv", fullpath);

                //Strip additional data from file
                string[] lines = File.ReadAllLines(fullpath);
                File.WriteAllLines(fullpath, lines.Take(lines.Count() - 78));

            }


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
