Module Module1

    Sub Main()
        'nc must be fully started before using THINC-API.
        'Okuma.[TypeOfMachine]DATAPI... dictates what kind of machine this program is merging with
        'the documentation says that these initialization lines of code MUST be executed
        Dim objMachine As Okuma.CMDATAPI.DataAPI.CMachine
        Dim objAtc As Okuma.CMDATAPI.DataAPI.CATC
        Dim objaxis As Okuma.CMDATAPI.DataAPI.CAxis
        Dim objBS As Okuma.CMDATAPI.DataAPI.CBallScrew
        Dim objCoolant As Okuma.CMDATAPI.DataAPI.CCoolant
        Dim objCMOP As Okuma.CMDATAPI.DataAPI.CMOPTool
        Dim objProgram As Okuma.CMDATAPI.DataAPI.CProgram
        Dim objSpec As Okuma.CMDATAPI.DataAPI.CSpec
        Dim objSpindle As Okuma.CMDATAPI.DataAPI.CSpindle

        Dim m_variables As Okuma.CMDATAPI.DataAPI.CVariables
        Dim comparedValue As Double 'this is the value to compare it to, it
        Dim variableValue As Double

        'create instance of CMachine class
        objMachine = New Okuma.CMDATAPI.DataAPI.CMachine

        'initialization of objMachine
        objMachine.Init()

        'Now, we create an instance of needed variables
        m_variables = New Okuma.CMDATAPI.DataAPI.CVariables

        'get the first value, and make sure it's valid. The value will never be less than .001, 0, or NULL.
        Do While (IsNothing(comparedValue) Or comparedValue < 0.001)
            comparedValue = m_variables.GetCommonVariableValue(195)
        Loop

        While 1 = 1 'this runs continuously, and keeps checking.
            variableValue = m_variables.GetCommonVariableValue(195)
            If (variableValue <> comparedValue) Then
                'FOCUS WINDOW! Something is wrong, time to have the console be shown to user

            End If
            'wait for 5 seconds
            Threading.Thread.Sleep(5000)
        End While


        'on program exit, release connections to the THINC-API
        objMachine.Close()
    End Sub

End Module
