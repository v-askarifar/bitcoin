using BTC;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTC_WindowsForms
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

            //Form4 frm = new Form4();

            //frm.TopMost = true;


            //frm.StartPosition = FormStartPosition.Manual;
            //frm.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - frm.Width,
            //                       Screen.PrimaryScreen.WorkingArea.Height - frm.Height);

            //Application.Run(frm);
            Application.Run(new frmbtc());
        }
    }
}
