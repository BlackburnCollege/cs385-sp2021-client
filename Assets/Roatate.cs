using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roatate : MonoBehaviour
{
    //this code was to help lane lol
    public Transform target;
    public float dist = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(new Vector3(0, dist * Time.deltaTime, 0));
        /*
        if (Vector3.Distance(transform.position, target.position) > dist)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, 1 * Time.deltaTime);
        }
        else
        {

            this.transform.RotateAround(target.position, Vector3.up, 20f * Time.deltaTime);
        }
        */
    }
}
