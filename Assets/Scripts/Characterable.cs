using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Characterable : MonoBehaviour
{
    string name { get; set; };

    float health { get; set; };

    float maxSpeed { get; set; };

    float acceleration { get; set; };

    //Weaponable weapon { get; set; };

    // Start is called before the first frame update
    void Start();

    // Update is called once per frame
    void Update();


    void Movement();


    void Attack();
}
