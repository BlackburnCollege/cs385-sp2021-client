using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : Weaponable
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Characterable ch = other.gameObject.GetComponent<Characterable>();
        if (ch != null)
        {
            if ((ch is Player))
            {
                ch.Health -= damage;

            }
        }
    }
   
}
