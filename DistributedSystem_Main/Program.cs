using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DistributedSystem_Main
{
    static class Program
    {
        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Systems.SystemExceptionHandler.Startup(); //用來抓例外事件

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());
        }


    }
}
