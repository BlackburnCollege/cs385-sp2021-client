using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebSocketController : Controllable
{
	public int indexMessage;
    private string[] messages;

    private Vector3 joy1;
    private bool a = false;
    private bool x = false;
    private bool y = false;
    private bool b = false;
    private void Start()
    {
        //GameObject.FindGameObjectWithTag("PlayerGM").GetComponent<PlayerManager>().AddController(this);
        GameObject.DontDestroyOnLoad(this);
    }

    public void Update()
    {
    }

	public override Vector3 Joystick1()
	{
        Update();
		return joy1;
	}

	public override bool InputA()
	{
        Update();
        return a;
	}

	public override bool InputB()
	{
		Update();
        return b;
	}

	public override bool InputX()
	{
        Update();
        return x;
	}

	public override bool InputY()
	{
		Update();
        return y;
	}
}
