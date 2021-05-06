using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// This class is the enemy script for the Ghost Enemy, detailing its AI, attacks, movement, and values such as HP. 
/// </summary>
public class GhostSmovement : Enemy
{
    // Value representing how much damage a ghost's attack does
    public float damage = 5.0f;
    
    // The range at which the ghost follows a player
    public float lookRadius = 10f;
    
    // Value representing the distance from the nearest player
    public float distanceFromPlayer;
    
    // GameObject representing the player the ghost is locked onto
    private GameObject player;
    
    // The list of all player in the game
    private GameObject[] playerList;
    
    // The position of the nearest player
    private Vector3 playerPos;

    // The ghosts "physical" body
    private Rigidbody rb;
    


    // Start is called before the first frame update
    /// <summary>
    /// Upon creation, the ghost will save the nearest player and its own body as private variables. 
    /// </summary>
    void Start()
    {
        player = getNearestPlayer();
        rb = GetComponent<Rigidbody>();
    }


    
    // Update is called once per frame
    /// <summary>
    /// Every frame, the ghost checks it HP, checks for the nearest player to follow, gets their positions and distance away from them.
    /// If the player is within the ghosts lookRadius the ghost will move towards them, and attack them if they are within range. 
    /// </summary>
    void Update()
    {
        checkHealth();
        
        
        player = getNearestPlayer();


        playerPos = new Vector3(player.transform.position.x, player.transform.position.y + 2, player.transform.position.z);
        
        distanceFromPlayer = Vector3.Distance(transform.position, playerPos);

      
        if (distanceFromPlayer <= lookRadius)
        {

            if (distanceFromPlayer < 1f)
            {
                

            } else
            {
                transform.position = Vector3.MoveTowards(transform.position, playerPos, MaxSpeed * Time.deltaTime);
            }

            if (distanceFromPlayer < 2.5f)
            {
                Attack();
                
            }                      
        }
        faceTarget();       
    }

    


    /// <summary>
    /// Checks the Objects HP. If it is below 0, the enemy is destroyed.
    /// </summary>
    private void checkHealth()
    {
        if (Health < 0)
        {
            if(transform.parent != null)
            {
                GameObject.Destroy(transform.parent.gameObject);
            }
            else
            {
                GameObject.Destroy(this.gameObject);
            }
        }
    }

    /// <summary>
    /// Gets the direction facing the player, calculates where it needs to rotate to face the player, then slowly rotates towards them. 
    /// </summary>
    void faceTarget()
    {
        Vector3 direction = (playerPos - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 2f);

    }

    /// <summary>
    /// Creates a list of all players, calculates the distance from the ghost to each one, then returns the closest player to follow. 
    /// </summary>
    /// <returns> The nearest player. </returns>
    GameObject getNearestPlayer()
    {
        playerList = GameObject.FindGameObjectsWithTag("Player");

        GameObject tempBest;

        if (playerList == null)
        {
            Debug.Log("There are no players");
            return null; 
        } 

        tempBest = playerList[0];
        
        if (playerList.Length < 2)
        {
            return tempBest;
        }

         

        for (int i = 1; i < playerList.Length; i++)
        {
            if (Vector3.Distance(this.transform.position, tempBest.transform.position) >= Vector3.Distance(this.transform.position, playerList[i].transform.position))
            {
                tempBest = playerList[i];
            }


        }

        return tempBest;

    }


    /// <summary>
    /// Transitions the ghosts attack animation which contains hit boxes that damage 
    /// </summary>
    public override void Attack()
    {
        GetComponentInChildren<Animator>().SetTrigger("Attack 0");
    }

    /// <summary>
    /// Checks if the object the ghost's hitbox collides with is indeed a player, and only deals damage if they are one. 
    /// </summary>
    /// <param name="other"> The Objects Collider/hitbox that is being hit. </param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            DealDamage(other.GetComponent<Characterable>());
        }

    }

    /// <summary>
    /// Subtracts health from the target that is being dealt damage. 
    /// </summary>
    /// <param name="target"> The Player character receiving the attack damage. </param>
    public virtual void DealDamage(Characterable target)
    {
        target.Health -= damage;
    }



    /// <summary>
    /// Movement happens in the update method, and is not called as a result. 
    /// </summary>
    public override void Movement()
    {
        throw new System.NotImplementedException();
    }
}

