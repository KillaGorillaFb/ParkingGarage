using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

/// <summary>
/// Developer:  Frankie Barrios
/// Date:       10/11/2018
/// Purpose:    Parking Garage Midterm Project
/// </summary>

namespace Exam2
{
    static class Driver
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new GarageForm());
        }
    }
}
