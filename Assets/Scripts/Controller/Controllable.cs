using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Controllable: MonoBehaviour
{
    //public int controller;

    public abstract Vector3 Joystick1();
    public abstract bool InputA();
    public abstract bool InputB();
    public abstract bool InputX();
    public abstract bool InputY();
}
