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
    private List<GameObject> enemyList;  
    // Start is called before the first frame update
    void Start()
    {
        PuzzleCompleted = false;
        random = Random.Range (minE, maxE);
        enemyList = new List<GameObject>();
        for (int i = 0; i < (int)random; i++)
        {
           
            GameObject tempEnemy = Instantiate(enemyType, new Vector3(Random.Range(min.x, max.x), Random.Range(min.y, max.y), Random.Range(min.z, max.z)), Quaternion.Euler(0, 0, 0));
            
            enemyList.Add (tempEnemy);
        }
        
       
    }
        
    // Update is called once per frame
    void Update()
    {
        int deathCount = 0;
        for (int i = 0; i < enemyList.Count; i++)
        {
            if (enemyList[i] == null)
            {
                deathCount++;

            }else if (enemyList[i].GetComponent<Characterable>().Health <= 0 )
            {
                deathCount++;
            }
        }
        if(deathCount == enemyList.Count)
        {
            PuzzleCompleted = true;
        }
    
    }
}
