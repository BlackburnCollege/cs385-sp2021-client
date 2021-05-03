using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeballEnemy : Enemy
{
    public float damage = 5.0f;

    public float lookRadius = 20f;

    public float distanceFromPlayer;

    public float bulletImpulse = 20.0f;

    public Rigidbody projectile;

    private bool pathMovement = true;

    private Vector3 oPosition;

    private Vector3 pathPosition1;

    private Vector3 pathPosition2;

    private GameObject player;

    private float _shootCoolDown;
    public float shootCooldown;

    public GameObject pathMarker1;

    public GameObject pathMarker2;

    private GameObject[] playerList;

    private Vector3 playerPos;


    // Start is called before the first frame update
    void Start()
    {
        _shootCoolDown = shootCooldown;
        player = getNearestPlayer();
        oPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        pathPosition1 = new Vector3(pathMarker1.transform.position.x, pathMarker1.transform.position.y, pathMarker1.transform.position.z);
        pathPosition2 = new Vector3(pathMarker2.transform.position.x, pathMarker2.transform.position.y, pathMarker2.transform.position.z);
    }

    // Update is called once per frame
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

            Attack();


        }
        
    }



    private void checkHealth()
    {
        if (Health <= 0)
        {
            Object.Destroy(gameObject);
        }
    }

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

    void faceTarget()
    {
        Vector3 direction = (playerPos - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 2f);
    }


    public override void Attack()
    {
        if(shootCooldown <= 0)
        {
            Rigidbody bullet = (Rigidbody)Instantiate(projectile, transform.position + transform.forward, transform.rotation);
            bullet.AddForce(transform.forward * bulletImpulse, ForceMode.Impulse);

            Destroy(bullet.gameObject, 2);
            shootCooldown = _shootCoolDown;
        }
        shootCooldown -= Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            DealDamage(other.GetComponent<Characterable>());
        }

    }

    public virtual void DealDamage(Characterable target)
    {
        target.Health -= damage;
    }




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
