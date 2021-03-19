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

    // Start is called before the first frame update
    void Start();

    // Update is called once per frame
    void Update();


    void Movement();


    void Attack();
}
