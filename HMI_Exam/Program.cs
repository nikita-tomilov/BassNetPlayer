using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace HMI_Exam
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            frmMain frm = new frmMain();
            frm.args = args;
            Application.Run(frm);
        }
    }
}
