using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// This is a abstract class that details variables and methods all enemies should have, such as a name, health, maxspeed,
/// acceleration, and weapon. 
/// </summary>
public abstract class Enemy: MonoBehaviour, Characterable
{
    // Name of enemy
    [SerializeField]
    private string _name;
    public string Name  // read-write instance property
    {
        get => _name;
        set => _name = value;
    }
    
    // Value representing the health of said enemy
    [SerializeField]
    private float _health;
    public float Health  // read-write instance property
    {
        get => _health;
        set => _health = value;
    }
    
    // The max speed at which the enemy can move 
    [SerializeField]
    private float _maxspeed;
    public float MaxSpeed  // read-write instance property
    {
        get => _maxspeed;
        set => _maxspeed = value;
    }

    // The rate at which the enemy accelerates as they move
    [SerializeField]
    private float _acceleration;
    public float Acceleration  // read-write instance property
    {
        get => _acceleration;
        set => _acceleration = value;
    }

    // The enemies weapon 
    public Weaponable weapon { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    // The enemies unity event for their attack. 
    public UnityEvent OnAttack = new UnityEvent();

    //private Weaponable _weapon;
    //public Weaponable Weapon  // read-write instance property
    //{
    //    get => _weapon;
    //    set => _weapon = value;
    //}


    /// <summary>
    /// Here so all enemies impliment a movement method
    /// </summary>
    public virtual void Movement()
    {

    }

    /// <summary>
    /// Here so all enemies impliment a attack method
    /// </summary>
    public virtual void Attack()
    {
        OnAttack.Invoke();
    }

}
