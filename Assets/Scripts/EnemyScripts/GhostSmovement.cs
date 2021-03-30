using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GhostSmovement : Enemy
{
    private Timer timer = new Timer();
    
    public float lookRadius = 10f;
    
    public float distanceFromPlayer;
    
    private GameObject player;
    
    private GameObject[] playerList;
    
    private Vector3 playerPos;

    private Rigidbody rb;
    


    // Start is called before the first frame update
    void Start()
    {
        player = getNearestPlayer();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        checkHealth();
        
        
        player = getNearestPlayer();


        playerPos = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
        
        distanceFromPlayer = Vector3.Distance(transform.position, playerPos);

        Debug.Log(distanceFromPlayer);

        if (distanceFromPlayer <= lookRadius)
        {

            transform.position = Vector3.MoveTowards(transform.position, playerPos, MaxSpeed * Time.deltaTime);

            if (distanceFromPlayer < 2.5f)
            {
                Attack();
                
            }                      

        }

        faceTarget();
               
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Weaponable")
        {
            
        }
            
    }

    private void checkHealth()
    {
        if (Health < 0)
        {
            Object.Destroy(gameObject);
        }
    }


    void faceTarget()
    {
        Vector3 direction = (playerPos - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);

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



    public void Attack()
    {
        GetComponentInChildren<Animator>().SetTrigger("Attack 0");
    }

    public void Movement()
    {
        throw new System.NotImplementedException();
    }
}

