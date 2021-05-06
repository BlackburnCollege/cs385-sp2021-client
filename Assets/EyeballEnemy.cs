using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script for the Eyeball enemy, controlling movement, attacks, and behavior of the enemy
/// </summary>
public class EyeballEnemy : Enemy
{
    // Value representing how much damage a eyeball's attack does
    public float damage = 5.0f;

    // The range at which the eyeball follows a player
    public float lookRadius = 20f;

    // Value representing the distance from the nearest player
    public float distanceFromPlayer;

    // Value representing the time between shots the eyeball fires 
    public float bulletImpulse = 20.0f;

    // The body of the projectile the eyeball shoots
    public Rigidbody projectile;

    // A boolean used for moving between two points
    private bool pathMovement = true;

    // Original position of the eye
    private Vector3 oPosition;

    // Position of path node 1
    private Vector3 pathPosition1;

    // Position of path node 2
    private Vector3 pathPosition2;

    // GameObject representing the player the ghost is locked onto
    private GameObject player;

    // Value representing the time between shots the eyeball fires
    private float _shootCoolDown;

    // Value representing the time between shots the eyeball fires
    public float shootCooldown;

    // Object that is the path node 1
    public GameObject pathMarker1;

    // Object that is the path node 2
    public GameObject pathMarker2;

    // The list of all player in the game
    private GameObject[] playerList;

    // The position of the nearest player
    private Vector3 playerPos;


    /// <summary>
    /// Upon creation, sets the shots cooldown, finds the nearest player, marks its position, and also marks the position of its pathing nodes
    /// </summary>
    void Start()
    {
        _shootCoolDown = shootCooldown;
        player = getNearestPlayer();
        oPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        pathPosition1 = new Vector3(pathMarker1.transform.position.x, pathMarker1.transform.position.y, pathMarker1.transform.position.z);
        pathPosition2 = new Vector3(pathMarker2.transform.position.x, pathMarker2.transform.position.y, pathMarker2.transform.position.z);
    }

    // Update is called once per frame
    /// <summary>
    /// Every frame, the Eyeball checks it HP, checks for the nearest player to aom, gets their positions and distance away from them.
    /// If the player is within the Eyeballs lookRadius the eyeball will shoot a laser at them as it moves along its determined path. 
    /// </summary>
    void Update()
    {
        checkHealth();

        player = getNearestPlayer();

        playerPos = new Vector3(player.transform.position.x, player.transform.position.y + 2, player.transform.position.z);

        distanceFromPlayer = Vector3.Distance(transform.position, playerPos);

        Movement();


        if (distanceFromPlayer <= lookRadius)
        {

            faceTarget();
            if (!player.GetComponent<Player>().IsDead)
            {
                Attack();
            }


        }
        
    }


    /// <summary>
    /// Checks the Objects HP. If it is below 0, the enemy is destroyed.
    /// </summary>
    private void checkHealth()
    {
        if (Health <= 0)
        {
            Object.Destroy(gameObject);
        }
    }

    /// <summary>
    /// Creates a list of all players, calculates the distance from the ghost to each one, then returns the closest player to aim at. 
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
            if (Vector3.Distance(this.transform.position, tempBest.transform.position) >= Vector3.Distance(this.transform.position, playerList[i].transform.position) && !playerList[i].GetComponent<Player>().IsDead)
            {
                tempBest = playerList[i];
            }


        }

        return tempBest;

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
    /// Shoots an projectile, waiting till the cooldown is over to shoot another object
    /// </summary>
    public override void Attack()
    {
        
        if(shootCooldown <= 0)
        {
            base.Attack();
            Rigidbody bullet = (Rigidbody)Instantiate(projectile, transform.position + transform.forward, transform.rotation);
            bullet.AddForce(transform.forward * bulletImpulse, ForceMode.Impulse);

            Destroy(bullet.gameObject, 2);
            shootCooldown = _shootCoolDown;
        }
        shootCooldown -= Time.deltaTime;
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
    /// Moves the Eyeball between two nodes at a fixed rate of speed
    /// </summary>
    public override void Movement()
    {
        if (pathMovement)
        {
            transform.position = Vector3.MoveTowards(transform.position, pathPosition1, MaxSpeed * Time.deltaTime);
            if (transform.position.x == pathPosition1.x)
            {
                pathMovement = false;
            }
        } else
        {
            transform.position = Vector3.MoveTowards(transform.position, pathPosition2, MaxSpeed * Time.deltaTime);
            if (transform.position.x == pathPosition2.x)
            {
                pathMovement = true;
            }
        }
    }








}
