using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Okuma.CMDATAPI.DataAPI;

namespace VariableOutputForms
{
    public partial class Form1 : Form
    {
        double comparedValue = 0, actualValue = 0;//values to compare
        CMachine objMachine = new CMachine();
        //supposedly "needed" variables, they're unused, but appear to be vital for initialization. This is where the testing is needed.
        //CATC objAtc = new CATC(); //this accesses memory that's locked. Error message says its probably due to corrupted memory. Gonna try and comment this out to see what happens.
        CAxis objAxis = new CAxis();
        CBallScrew objBS = new CBallScrew();
        CCoolant objCoolant = new CCoolant();
        //CMOPTool objCMP = new CMOPTool(); //this is also throwing a memory error, gonna comment this out too.
        CProgram objProgram = new CProgram();
        CSpec objSpec = new CSpec();
        CSpindle objSPindle = new CSpindle();

        CVariables objVariables = new CVariables();
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

        private void btnOK_Click(object sender, EventArgs e) //event handler, on btnOK click
        {
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            do
            {
                comparedValue = objVariables.GetCommonVariableValue(195); //resets compared value
            } while (comparedValue != 0 || Math.Abs(comparedValue) > 0.01);
        }
    }
}
