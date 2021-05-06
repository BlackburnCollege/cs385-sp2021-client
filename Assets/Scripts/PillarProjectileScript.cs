using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The Pillar Projectile is the script that controls the operations of the shooting pillars projectiles. 
/// </summary>
public class PillarProjectileScript : Weaponable
{
    // The original position of the projectile on the shooter pillars
    private Vector3 oPosition;

    /// <summary>
    /// Upon creation sets the objects original position as well as its damage
    /// </summary>
    void Start()
    {
        oPosition = transform.position;
        damage = 100f;
    }

    // Update is called once per frame
    /// <summary>
    /// Nothing happenes each frame
    /// </summary>
    void Update()
    {
        
    }

    /// <summary>
    /// Checks if what is being collided with is not a player and does damage to them if they are not. Upon collision, the object will be destroyed
    /// and respawn at its original position on the pillar. If the projectile misses, afer a certain amount of time, the ball will be returned to 
    /// its original position.
    /// </summary>
    /// <param name="collision"> The Object that the projectile is collding with (Specifically their hitbox) </param>
    private void OnCollisionEnter(Collision collision)
    {
        Characterable ch = collision.gameObject.GetComponent<Characterable>();
        if (ch != null)
        {
            if (!(ch is Player))
            {
                ch.Health -= damage;
            }
        }


        this.GetComponent<Rigidbody>().velocity = Vector3.zero;
        transform.localScale = new Vector3(.1f, .1f, .1f);
        transform.position = oPosition;
        StopAllCoroutines();
        StartCoroutine(scaleEffect());

    }

    /// <summary>
    /// A method used to create a increasing size effect over time just when the ball respawns. The player must wait a bit of time for the ball 
    /// to return to its original size after being hit. 
    /// </summary>
    /// <returns> An IEnumerator, that is used for assycronous method </returns>
    private IEnumerator scaleEffect()
    {

        while (transform.lossyScale.x <= .5f)
        {
            transform.localScale += new Vector3(.1f, .1f, .1f) * Time.deltaTime;
            yield return null;
        }
                             
    }

    /// <summary>
    /// After a certain amount of time, sets the projectile to its original position and causes the scale effect
    /// </summary>
    /// <returns> An IEnumerator, that is used for assycronous method </returns>
    private IEnumerator Timer()
    {
        yield return new WaitForSeconds(3);

        this.GetComponent<Rigidbody>().velocity = Vector3.zero;
        transform.localScale = new Vector3(.1f, .1f, .1f);
        transform.position = oPosition;
        StartCoroutine(scaleEffect());
    }

    /// <summary>
    /// Started method to start the corritines in the object that allows for its attack to work. 
    /// </summary>
    public override void StartAttack()
    {
        StopAllCoroutines();
        StartCoroutine(Timer());

    }



}
