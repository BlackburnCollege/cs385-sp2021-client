using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostSmovement : MonoBehaviour
{

    private float speed = 2.0f;
    private GameObject player;
    private GameObject[] playerList;
    private Vector3 playerPos;


    // Start is called before the first frame update
    void Start()
    {
        player = getNearestPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        player = getNearestPlayer();



        playerPos = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, playerPos, speed * Time.deltaTime);
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


}

