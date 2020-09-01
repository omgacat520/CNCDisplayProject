using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace VariableOutputForms
{
    public partial class Form1 : Form
    {
        bool isPoppedUp = false; //this halts the checks if the window is visible
        double comparedValue = 0, actualValue = 0;//values to compare
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) //onload, execute this stuff
        {
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized; //hide the form when it's created, no need to see it until the variables are different. This is the "minimize" effect. Change the last part of it to Maximized when needing to be maximized.

            do
            {
                var objMachine = new Okuma.CMDATAPI.DataAPI.CMachine();
                objMachine.Init();
                var objVariables = new Okuma.CMDATAPI.DataAPI.CVariables(); //object used to retrieve variables from API

                objVariables.GetCommonVariableValue(195);

                objMachine.Close();
            } while (comparedValue != 0 || Math.Abs(comparedValue) > 0.01);

            do
            {
                var objMachine = new Okuma.CMDATAPI.DataAPI.CMachine();
                objMachine.Init();
                var objVariables = new Okuma.CMDATAPI.DataAPI.CVariables(); //object used to retrieve variables from API

                actualValue = objVariables.GetCommonVariableValue(195);
                lblActualValue.Text = $"Actual Value: {actualValue}";
                lblComparedValue.Text = $"Compared Value: {comparedValue}";
                if (actualValue != comparedValue)
                {
                    if(!isPoppedUp)
                    {
                        this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
                        lblActualValue.Visible = true;
                        lblComparedValue.Visible = true;
                        isPoppedUp = true;
                    }
                }

                objMachine.Close();
            } while (1 == 1);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            isPoppedUp = false;
            do
            {
                var objVariables = new Okuma.CMDATAPI.DataAPI.CVariables(); //object used to retrieve variables from API
                objVariables.GetCommonVariableValue(195);
            } while (comparedValue != 0 || Math.Abs(comparedValue) > 0.01);
        }
    }
}
