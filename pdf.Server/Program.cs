﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pdf.Server
{
    internal static class Program
    {
        // da li ovde napraviti singleton za formu, da bih imao pristup svemu

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            SrvMainForm srv_form = new SrvMainForm();
            Controller.Instance.SetForm(srv_form);
            Application.Run(srv_form);
        }
    }
}
