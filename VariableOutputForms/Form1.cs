using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace VariableOutputForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) //onload, execute this stuff
        {
            double comparedValue = 0, actualValue = 0;//values to compare
            var objVariables = new Okuma.CMDATAPI.DataAPI.CVariables(); //object used to retrieve variables from API

            this.WindowState = System.Windows.Forms.FormWindowState.Minimized; //hide the form when it's created, no need to see it until the variables are different. This is the "minimize" effect. Change the last part of it to Maximized when needing to be maximized.

            lblComparedValue.Visible = false; //these values should be hidden until the user needs them.
            lblActualValue.Visible = true;

            do
            {
                objVariables.GetCommonVariableValue(195);
            } while (comparedValue != 0 || Math.Abs(comparedValue) > 0.01);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
        }
    }
}
