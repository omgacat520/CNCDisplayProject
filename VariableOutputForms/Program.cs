using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Okuma;

namespace VariableOutputForms
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
            catch (System.IO.FileNotFoundException notFound)
            {
                MessageBox.Show(notFound.Message.ToString(), "File Not Found");
            }
            catch(Exception E)
            {
                MessageBox.Show(E.Message.ToString());
            }
        }
    }
}
