using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxingGloves : Weaponable
{
    // Start is called before the first frame update
    void Start()
    {
        if(transform.parent.GetComponent<Characterable>() != null)
        {
            Pickup(transform.parent.GetComponent<Characterable>());
            if(transform.parent.GetComponent<Characterable>() is Player)
            {
                ((Player)transform.parent.GetComponent<Characterable>()).weapon = this;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
        Characterable character = other.GetComponent<Characterable>();
        if (character != null && Owner != null)
        {
            if(Owner != character)
            {
                DealDamage(character);
            }
        }
        else
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if(rb != null)
            {
                rb.AddForce(transform.forward * 1000f);
            }
        }


    }
}
