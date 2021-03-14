using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardController : Controllable
{
    public int connectedContNum;
    

    public StandardController(int inputContNum)
    {
        connectedContNum = inputContNum;
    }
    public override bool InputA()
    {
        return InputManger.InputA(connectedContNum);
        
    }

    public override bool InputB()
    {
        return InputManger.InputB(connectedContNum);
    }

    public override bool InputX()
    {
        return InputManger.InputX(connectedContNum);
    }

    public override bool InputY()
    {
        return InputManger.InputY(connectedContNum);
    }

    public override Vector3 Joystick1()
    {
        return InputManger.InputJoy(connectedContNum);
    }
        
}
