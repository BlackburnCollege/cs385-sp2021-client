﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy: MonoBehaviour, Characterable
{
    [SerializeField]
    private string _name;
    public string Name  // read-write instance property
    {
        get => _name;
        set => _name = value;
    }
    [SerializeField]
    private float _health;
    public float Health  // read-write instance property
    {
        get => _health;
        set => _health = value;
    }
    [SerializeField]
    private float _maxspeed;
    public float MaxSpeed  // read-write instance property
    {
        get => _maxspeed;
        set => _maxspeed = value;
    }
    [SerializeField]
    private float _acceleration;
    public float Acceleration  // read-write instance property
    {
        get => _acceleration;
        set => _acceleration = value;
    }
    public Weaponable weapon { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    //private Weaponable _weapon;
    //public Weaponable Weapon  // read-write instance property
    //{
    //    get => _weapon;
    //    set => _weapon = value;
    //}



    public virtual void Movement()
    {

    }


    public virtual void Attack()
    {

    }

}
