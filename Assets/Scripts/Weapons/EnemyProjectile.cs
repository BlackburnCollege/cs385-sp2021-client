using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The version of the Projectile weaponthe specifcally checked if what it is colliding is a player and deals damage to them. Shot from an enemy.
/// </summary>
public class EnemyProjectile : Weaponable
{
    // Start is called before the first frame update
    /// <summary>
    /// Nothing is done on start up
    /// </summary>
    void Start()
    {
        
    }

    // Update is called once per frame
    /// <summary>
    /// Nothing is done each frame
    /// </summary>
    void Update()
    {
        
    }

    /// <summary>
    /// On collision, checks if the object is a player, and if they are does damage. 
    /// </summary>
    /// <param name="other"> The Objects' collider that the projectile is hitting </param>
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
