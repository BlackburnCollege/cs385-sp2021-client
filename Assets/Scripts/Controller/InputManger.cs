using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InputManger
{

    public static Vector3 InputJoy(int controler)
    {
        
            Vector3 hVector = new Vector3();
            switch (controler)
            {
                case 1:
                    hVector = Joystick1();
                    break;
                case 2:
                    hVector = Joystick2();
                    break;
                case 3:
                    hVector = Joystick3();
                    break;
                case 4:
                    hVector = Joystick4();
                    break;
                case 5:
                    hVector = Joystick5();
                    break;
                case 6:
                    hVector = Joystick6();
                    break;
                case 7:
                    hVector = Joystick7();
                    break;
                case 8:
                    hVector = Joystick8();
                    break;
                default:
                    hVector = Joystick1();
                    break;
            }
            return hVector;
    }
    
    public static bool InputA(int controler)
    {
        bool i;
        switch (controler)
        {
            case 1:
                i = Abutton1();
                break;
            case 2:
                i = Abutton2();
                break;
            case 3:
                i = Abutton3();
                break;
            case 4:
                i = Abutton4();
                break;
            case 5:
                i = Abutton5();
                break;
            case 6:
                i = Abutton6();
                break;
            case 7:
                i = Abutton7();
                break;
            case 8:
                i = Abutton8();
                break;
            default:
                i = Abutton1();
                break;
        }
        return i;
    }

    public static bool InputB(int controler)
    {
        bool i;
        switch (controler)
        {
            case 1:
                i = Bbutton1();
                break;
            case 2:
                i = Bbutton2();
                break;
            case 3:
                i = Bbutton3();
                break;
            case 4:
                i = Bbutton4();
                break;
            case 5:
                i = Bbutton5();
                break;
            case 6:
                i = Bbutton6();
                break;
            case 7:
                i = Bbutton7();
                break;
            case 8:
                i = Bbutton8();
                break;
            default:
                i = Bbutton1();
                break;
        }
        return i;
    }

    public static bool InputX(int controler)
    {
        bool i;
        switch (controler)
        {
            case 1:
                i = Xbutton1();
                break;
            case 2:
                i = Xbutton2();
                break;
            case 3:
                i = Xbutton3();
                break;
            case 4:
                i = Xbutton4();
                break;
            case 5:
                i = Xbutton5();
                break;
            case 6:
                i = Xbutton6();
                break;
            case 7:
                i = Xbutton7();
                break;
            case 8:
                i = Xbutton8();
                break;
            default:
                i = Xbutton1();
                break;
        }
        return i;
    }
    public static bool InputY(int controler)
    {
        bool i;
        switch (controler)
        {
            case 1:
                i = Ybutton1();
                break;
            case 2:
                i = Ybutton2();
                break;
            case 3:
                i = Ybutton3();
                break;
            case 4:
                i = Ybutton4();
                break;
            case 5:
                i = Ybutton5();
                break;
            case 6:
                i = Ybutton6();
                break;
            case 7:
                i = Ybutton7();
                break;
            case 8:
                i = Ybutton8();
                break;
            default:
                i = Ybutton1();
                break;
        }
        return i;
    }

    public static float Horizontal1()
    {
        float r = 0.0f;
        r += Input.GetAxis("J_MainH");
        r += Input.GetAxis("K_MainH");
        return Mathf.Clamp(r, -1.0f, 1.0f);
    }
    public static float Vertical1()
    {
        float r = 0.0f;
        r += Input.GetAxis("J_MainV");
        r += Input.GetAxis("K_MainV");
        return Mathf.Clamp(r, -1.0f, 1.0f);
    }
    public static Vector3 Joystick1()
    {
        return new Vector3(Horizontal1(), Vertical1(), 0);
    }


    public static bool Abutton1()
    {
        return Input.GetButtonDown("A_button");
    }
    public static bool Bbutton1()
    {
        return Input.GetButtonDown("B_button");
    }
    public static bool Xbutton1()
    {
        return Input.GetButtonDown("X_button");
    }
    public static bool Ybutton1()
    {
        return Input.GetButtonDown("Y_button");
    }





    public static float Horizontal2()
    {
        float r = 0.0f;
        r += Input.GetAxis("J2_MainH");
        return Mathf.Clamp(r, -1.0f, 1.0f);
    }
    public static float Vertical2()
    {
        float r = 0.0f;
        r += Input.GetAxis("J2_MainV");
        return Mathf.Clamp(r, -1.0f, 1.0f);
    }
    public static Vector3 Joystick2()
    {
        return new Vector3(Horizontal2(), Vertical2(), 0);
    }


    public static bool Abutton2()
    {
        return Input.GetButtonDown("A2_button");
    }
    public static bool Bbutton2()
    {
        return Input.GetButtonDown("B2_button");
    }
    public static bool Xbutton2()
    {
        return Input.GetButtonDown("X2_button");
    }
    public static bool Ybutton2()
    {
        return Input.GetButtonDown("Y2_button");
    }

    public static float Horizontal3()
    {
        float r = 0.0f;
        r += Input.GetAxis("J3_MainH");
        return Mathf.Clamp(r, -1.0f, 1.0f);
    }
    public static float Vertical3()
    {
        float r = 0.0f;
        r += Input.GetAxis("J3_MainV");
        return Mathf.Clamp(r, -1.0f, 1.0f);
    }
    public static Vector3 Joystick3()
    {
        return new Vector3(Horizontal3(), Vertical3(), 0);
    }


    public static bool Abutton3()
    {
        return Input.GetButtonDown("A3_button");
    }
    public static bool Bbutton3()
    {
        return Input.GetButtonDown("B3_button");
    }
    public static bool Xbutton3()
    {
        return Input.GetButtonDown("X3_button");
    }
    public static bool Ybutton3()
    {
        return Input.GetButtonDown("Y3_button");
    }



    public static float Horizontal4()
    {
        float r = 0.0f;
        r += Input.GetAxis("J4_MainH");
        return Mathf.Clamp(r, -1.0f, 1.0f);
    }
    public static float Vertical4()
    {
        float r = 0.0f;
        r += Input.GetAxis("J4_MainV");
        return Mathf.Clamp(r, -1.0f, 1.0f);
    }
    public static Vector3 Joystick4()
    {
        return new Vector3(Horizontal4(), Vertical4(), 0);
    }


    public static bool Abutton4()
    {
        return Input.GetButtonDown("A4_button");
    }
    public static bool Bbutton4()
    {
        return Input.GetButtonDown("B4_button");
    }
    public static bool Xbutton4()
    {
        return Input.GetButtonDown("X4_button");
    }
    public static bool Ybutton4()
    {
        return Input.GetButtonDown("Y4_button");
    }


    public static float Horizontal5()
    {
        float r = 0.0f;
        r += Input.GetAxis("J5_MainH");
        return Mathf.Clamp(r, -1.0f, 1.0f);
    }
    public static float Vertical5()
    {
        float r = 0.0f;
        r += Input.GetAxis("J5_MainV");
        return Mathf.Clamp(r, -1.0f, 1.0f);
    }
    public static Vector3 Joystick5()
    {
        return new Vector3(Horizontal5(), Vertical5(), 0);
    }


    public static bool Abutton5()
    {
        return Input.GetButtonDown("A5_button");
    }
    public static bool Bbutton5()
    {
        return Input.GetButtonDown("B5_button");
    }
    public static bool Xbutton5()
    {
        return Input.GetButtonDown("X5_button");
    }
    public static bool Ybutton5()
    {
        return Input.GetButtonDown("Y5_button");
    }


    public static float Horizontal6()
    {
        float r = 0.0f;
        r += Input.GetAxis("J6_MainH");
        return Mathf.Clamp(r, -1.0f, 1.0f);
    }
    public static float Vertical6()
    {
        float r = 0.0f;
        r += Input.GetAxis("J6_MainV");
        return Mathf.Clamp(r, -1.0f, 1.0f);
    }
    public static Vector3 Joystick6()
    {
        return new Vector3(Horizontal6(), Vertical6(), 0);
    }


    public static bool Abutton6()
    {
        return Input.GetButtonDown("A6_button");
    }
    public static bool Bbutton6()
    {
        return Input.GetButtonDown("B6_button");
    }
    public static bool Xbutton6()
    {
        return Input.GetButtonDown("X6_button");
    }
    public static bool Ybutton6()
    {
        return Input.GetButtonDown("Y6_button");
    }



    public static float Horizontal7()
    {
        float r = 0.0f;
        r += Input.GetAxis("J7_MainH");
        return Mathf.Clamp(r, -1.0f, 1.0f);
    }
    public static float Vertical7()
    {
        float r = 0.0f;
        r += Input.GetAxis("J7_MainV");
        return Mathf.Clamp(r, -1.0f, 1.0f);
    }
    public static Vector3 Joystick7()
    {
        return new Vector3(Horizontal7(), Vertical7(), 0);
    }


    public static bool Abutton7()
    {
        return Input.GetButtonDown("A7_button");
    }
    public static bool Bbutton7()
    {
        return Input.GetButtonDown("B7_button");
    }
    public static bool Xbutton7()
    {
        return Input.GetButtonDown("X7_button");
    }
    public static bool Ybutton7()
    {
        return Input.GetButtonDown("Y7_button");
    }



    public static float Horizontal8()
    {
        float r = 0.0f;
        r += Input.GetAxis("J8_MainH");
        return Mathf.Clamp(r, -1.0f, 1.0f);
    }
    public static float Vertical8()
    {
        float r = 0.0f;
        r += Input.GetAxis("J8_MainV");
        return Mathf.Clamp(r, -1.0f, 1.0f);
    }
    public static Vector3 Joystick8()
    {
        return new Vector3(Horizontal8(), Vertical8(), 0);
    }


    public static bool Abutton8()
    {
        return Input.GetButtonDown("A8_button");
    }
    public static bool Bbutton8()
    {
        return Input.GetButtonDown("B8_button");
    }
    public static bool Xbutton8()
    {
        return Input.GetButtonDown("X8_button");
    }
    public static bool Ybutton8()
    {
        return Input.GetButtonDown("Y8_button");
    }

}