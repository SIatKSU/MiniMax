using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;       //because we use DllImport, to show/hide console window




namespace Project2
{

    static class Program
    {
        [DllImport("Kernel32")]
        private static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        public static void ShowConsole()
        {
        // Show the console window
        //Adapted from http://soltveit.org/c-make-console-application-invisible/
        // and http://stackoverflow.com/questions/472282/show-console-in-windows-application/15079092#15079092
            IntPtr hwnd;
            hwnd = GetConsoleWindow();

        /*
        //since it is a console application, console window will always exist at the start; therefore below code is not necessary atm.
        if (hwnd == IntPtr.Zero)
        {
            AllocConsole();
        }
        else
        {           
         ShowWindow(hwnd, SW_SHOW);
         */

             SetForegroundWindow(hwnd);  //bring it to the foreground           
        }

    }
}
