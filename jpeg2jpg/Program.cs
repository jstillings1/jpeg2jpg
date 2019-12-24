using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
// Slapped together by Jeremiah Stillings
// This is to solve the issue of .JPEG not being accepted on some PPI uploads for work
// 12/24/2019
// jstillings2@outlook.com

namespace jpeg2jpg
{
    static class Program
    {
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
    }
}
