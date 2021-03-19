using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weaponable : MonoBehaviour
{

    float Damage { get; set; }

    float AttackSpeed { get; set; }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    

    public abstract void OnCollision();


    public abstract void OnDamage();


    public void Pickup(Characterable pickUper)
    {

    }


}
