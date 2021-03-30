using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingObjectDamage : Weaponable
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Characterable ch = collision.gameObject.GetComponent<Characterable>();
        if(ch != null)
        {
            if (!(ch is Player))
            {
                ch.Health -= damage;
                Destroy(this);
            }
        }
    }
}
