using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GhostSmovement : MonoBehaviour, Characterable
{

    private float speed = 2.0f;
    
    public float lookRadius = 10f;
    
    public float distanceFromTarget = 3f;
    
    private GameObject player;
    
    private GameObject[] playerList;
    
    private Vector3 playerPos;

    private Rigidbody rb;

    public string Name { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public float Health { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public float MaxSpeed { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public float Acceleration { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public Weaponable weapon { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }


    // Start is called before the first frame update
    void Start()
    {
        player = getNearestPlayer();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        player = getNearestPlayer();


        playerPos = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
        
        float distanceFromPlayer = Vector3.Distance(transform.position, playerPos);

        Debug.Log(distanceFromPlayer);

        if (distanceFromPlayer <= lookRadius)
        {

            transform.position = Vector3.MoveTowards(transform.position, playerPos, speed * Time.deltaTime);

            if (distanceFromPlayer < 1.5f)
            {
                Attack();
            }
            

        }

        faceTarget();

       
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
        GetComponentInChildren<Animator>().SetBool("Attack", true);
    }

    public void Movement()
    {
        throw new System.NotImplementedException();
    }
}

