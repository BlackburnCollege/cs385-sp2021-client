using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillEnemysPuzzle : MonoBehaviour, Puzzles
{
    public Vector3 min = new Vector3(0,0,0);
    public Vector3 max= new Vector3(4,4,4);
    public float minE = 1;
    public float maxE = 4;
    public GameObject enemyType;
    public bool PuzzleCompleted { get; set; }
    private float random;
    public List<GameObject> enemyList;
    /// <summary>
    /// Start is called before the first frame update
    /// This is also where the enemies are made
    /// </summary>

    void Start()
    {
        PuzzleCompleted = false;
        random = Random.Range (minE, maxE);
        if (enemyList == null)
        {
            enemyList = new List<GameObject>();
        }
        // this loop makes a random number of enemies
        for (int i = 0; i < (int)random; i++)
        {
           
            GameObject tempEnemy = Instantiate(enemyType, transform.position + new Vector3(Random.Range(min.x, max.x), Random.Range(min.y, max.y), Random.Range(min.z, max.z)), Quaternion.Euler(0, 0, 0));
            
            enemyList.Add (tempEnemy);
        }
        
        foreach(GameObject enem in enemyList)
        {
            enem.SetActive(false);
        }
       
    }


    /// <summary>
    /// Update is called once per frame 
    /// This checks the number of enemies in a room and if they are all dead the puzzle will complete
    /// </summary>    
    void Update()
    {
        int deathCount = 0;
        for (int i = 0; i < enemyList.Count; i++)
        {
            if (enemyList[i] == null)
            {
                deathCount++;

            }else if (enemyList[i].GetComponentInChildren<Enemy>().Health <= 0)
            {
                deathCount++;
            }
        }
        if(deathCount == enemyList.Count)
        {
            PuzzleCompleted = true;
        }
    
    }
    /// <summary>
    /// This sets all of the emenies to active or alive
    /// </summary>

    public void StartPuzzle()
    {
        foreach (GameObject enem in enemyList)
        {
            enem.SetActive(true);
        }
    }
}
