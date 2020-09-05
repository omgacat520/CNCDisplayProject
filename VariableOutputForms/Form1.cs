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
        double comparedValue = 0, actualValue = 0;//values to compare
        Okuma.CMDATAPI.DataAPI.CMachine objMachine = new Okuma.CMDATAPI.DataAPI.CMachine();
        Okuma.CMDATAPI.DataAPI.CVariables objVariables = new Okuma.CMDATAPI.DataAPI.CVariables();
        public Form1()
        {
            InitializeComponent();
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized; //hide the form when it's created, no need to see it until the variables are different. This is the "minimize" effect. Change the last part of it to Maximized when needing to be maximized.

            objMachine.Init();
            do
            {
                objVariables.GetCommonVariableValue(195);
            } while (comparedValue != 0 || Math.Abs(comparedValue) > 0.01);
            objMachine.Close();

            do
            {
                objMachine.Init();

                actualValue = objVariables.GetCommonVariableValue(195);
                lblActualValue.Text = $"Actual Value: {actualValue}";
                lblComparedValue.Text = $"Compared Value: {comparedValue}";
                if (actualValue != comparedValue)
                {
                    if (this.WindowState == System.Windows.Forms.FormWindowState.Minimized)
                    {
                        this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
                        lblActualValue.Visible = true;
                        lblComparedValue.Visible = true;
                    }
                }

                objMachine.Close();
                System.Threading.Thread.Sleep(2000);
            } while (1 == 1);
        }

        private void Form1_Load(object sender, EventArgs e) //onload, execute this stuff
        {
            
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            do
            {
                comparedValue = objVariables.GetCommonVariableValue(195); //resets compared value
            } while (comparedValue != 0 || Math.Abs(comparedValue) > 0.01);
        }
    }
}
