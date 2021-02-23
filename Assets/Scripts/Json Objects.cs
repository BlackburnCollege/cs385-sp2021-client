using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonObjects : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private class User
    {
        public string name;
        public int ip;
        public Controller controller;
    }

    private class Controller
    {
        public Joystick joystick;
        public Buttons buttons;
    }

    private class Buttons
    {
        public bool a = false;
        public bool b = false;
        public bool x = false;
        public bool y = false;
        public bool start = false;
    }

    public class Joystick
    {
        public Vector2 x;
        public Vector2 y;
    }

}

