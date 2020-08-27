using System;
using System.Threading;
using Okuma;

namespace VariableOutputCSProject
{
    class Program
    {
        static void Main(string[] args)
        {
            //NC must be fully started before using THiNC API
            //the namespace after Okuma dictates the type of physical hardware these methods should be loaded on.
            //The documentation says that these initialization lines MUST be executed
            var objMachine = new Okuma.CMDATAPI.DataAPI.CMachine();
            var objAtc = new Okuma.CMDATAPI.DataAPI.CATC();
            var objaxis = new Okuma.CMDATAPI.DataAPI.CAxis();
            var objBS = new Okuma.CMDATAPI.DataAPI.CBallScrew();
            var objCoolant = new Okuma.CMDATAPI.DataAPI.CCoolant();
            var objCMOP = new Okuma.CMDATAPI.DataAPI.CMOPTool();
            var objProgram = new Okuma.CMDATAPI.DataAPI.CProgram();
            var objSpec = new Okuma.CMDATAPI.DataAPI.CSpec();
            var objSpindle = new Okuma.CMDATAPI.DataAPI.CSpindle();

            //these are the variables I actually need
            var objVariables = new Okuma.CMDATAPI.DataAPI.CVariables();

            double comparedValue;
            double actualValue;

            do
            { //loop this until the value to be compared has been set correctly
                comparedValue = objVariables.GetCommonVariableValue(195);
            } while (comparedValue != 0 || comparedValue < 0.001);

            while (1 == 1) //repeat forever
            {
                actualValue = objVariables.GetCommonVariableValue(195);
                if (comparedValue != actualValue)
                { //problem detected!
                    Console.WriteLine(actualValue);
                }
                Thread.Sleep(5000); //wait 5 seconds then run it again
            }
        }
    }
}
