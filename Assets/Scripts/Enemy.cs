﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy:Characterable
{

    private string _name;
    public string Name  // read-write instance property
    {
        get => _name;
        set => _name = value;
    }

    private string _health;
    public float Health  // read-write instance property
    {
        get => _health;
        set => _health = value;
    }

    private float _maxspeed;
    public float Maxspeed  // read-write instance property
    {
        get => _maxspeed;
        set => _maxspeed = value;
    }

    private float _acceleration;
    public float Acceleration  // read-write instance property
    {
        get => _acceleration;
        set => _acceleration = value;
    }

    private Weaponable _weapon;
    public Weaponable Weapon  // read-write instance property
    {
        get => _weapon;
        set => _weapon = value;
    }


    // Start is called before the first frame update
    void Start() 
    { 
    
    }


    void Update()
    {

    }


    public void Movement()
    {

    }


    public void Attack()
    {

    }

}
