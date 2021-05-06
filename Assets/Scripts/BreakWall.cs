using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Used to make walls destructable
/// </summary>
public class BreakWall : Enemy
{
    
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
   /// <summary>
   /// If the walls HP reached below 0, it is destroyed
   /// </summary>
    void Update()
    {
        if (Health < 0)
        {
            Object.Destroy(gameObject);
        }
    }













}
