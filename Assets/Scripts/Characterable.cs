using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Characterable
{
    string Name { get; set; }

    float Health { get; set; }

    float MaxSpeed { get; set; }

    float Acceleration { get; set; }

    //Weaponable weapon { get; set; };

   


    void Movement();


    void Attack();
}
