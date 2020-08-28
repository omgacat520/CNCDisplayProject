using System;
using System.Collections.Generic;
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
            //gonna instantiate the API values here

            //"required" values, if these aren't needed, we could save a bit on ram with these objects.
            //I'm gonna put the actual value we need inside the Form1.cs code so it executes and has access from within the form objects' encapsulation.
            var objMachine = new Okuma.CMDATAPI.DataAPI.CMachine();
            var objAtc = new Okuma.CMDATAPI.DataAPI.CMachine();
            var objAxis = new Okuma.CMDATAPI.DataAPI.CAxis();
            var objBS = new Okuma.CMDATAPI.DataAPI.CBallScrew();
            var objCoolant = new Okuma.CMDATAPI.DataAPI.CCoolant();
            var objCMOP = new Okuma.CMDATAPI.DataAPI.CMOPTool();
            var objProgram = new Okuma.CMDATAPI.DataAPI.CProgram();
            var objSpec = new Okuma.CMDATAPI.DataAPI.CSpec();
            var objSpindle = new Okuma.CMDATAPI.DataAPI.CSpindle();

            objMachine.Init();
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
