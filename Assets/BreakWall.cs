using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakWall : Enemy
{
    
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Health < 0)
        {
            Object.Destroy(gameObject);
        }
    }













}
