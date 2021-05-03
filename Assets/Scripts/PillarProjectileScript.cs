using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarProjectileScript : Weaponable
{

    private Vector3 oPosition;

    void Start()
    {
        oPosition = transform.position;
        damage = 100f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Characterable ch = collision.gameObject.GetComponent<Characterable>();
        if (ch != null)
        {
            if (!(ch is Player))
            {
                ch.Health -= damage;
            }
        }


        this.GetComponent<Rigidbody>().velocity = Vector3.zero;
        transform.localScale = new Vector3(.1f, .1f, .1f);
        transform.position = oPosition;
        StartCoroutine(scaleEffect());

    }

    private IEnumerator scaleEffect()
    {

        while (transform.lossyScale.x <= .5f)
        {
            transform.localScale += new Vector3(.1f, .1f, .1f) * Time.deltaTime;
            yield return null;
        }
                             
    }

    private IEnumerator Timer()
    {
        yield return new WaitForSeconds(3);

        this.GetComponent<Rigidbody>().velocity = Vector3.zero;
        transform.localScale = new Vector3(.1f, .1f, .1f);
        transform.position = oPosition;
        StartCoroutine(scaleEffect());
    }

    public override void StartAttack()
    {
        StartCoroutine(Timer());

    }



}
