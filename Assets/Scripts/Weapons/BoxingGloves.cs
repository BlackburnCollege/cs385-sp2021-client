using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxingGloves : Weaponable
{
    public ParticleSystem particle;
    public GameObject gloveLeft;
    public GameObject gloveRight;
    private GameObject[] Attachments = new GameObject[2];
    // Start is called before the first frame update
    void Start()
    {
        if(transform.parent.GetComponent<Characterable>() != null)
        {
            Pickup(transform.parent.GetComponent<Characterable>());
            if(transform.parent.GetComponent<Characterable>() is Player)
            {
                ((Player)transform.parent.GetComponent<Characterable>()).weapon = this;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void StartAttack()
    {
        base.StartAttack();
        //particle.enableEmission = true;
        particle.Play();
        particle.gameObject.SetActive(true);

    }

    public override void OnAttackEnd()
    {
        base.OnAttackEnd();
        //particle.enableEmission = false;
        particle.Pause();
        particle.gameObject.SetActive(false);
    }

    public override void Pickup(Characterable pickUper)
    {
        base.Pickup(pickUper);
        Attachments[0] = Instantiate(gloveLeft, animator.GetBoneTransform(HumanBodyBones.LeftHand));
        Attachments[0] = Instantiate(gloveRight, animator.GetBoneTransform(HumanBodyBones.RightHand));
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if(Owner != null)
            {
                if(Owner is Player)
                {
                    return;
                }
            }
        }
        Characterable character = other.GetComponent<Characterable>();
        if (character != null && Owner != null)
        {
            if(Owner != character)
            {
                DealDamage(character);
            }
        }
        else
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if(rb != null)
            {
                
                
                if(other.GetComponent<PillarProjectileScript>() == null)
                {
                    Weaponable wep = other.gameObject.AddComponent<FlyingObjectDamage>();
                    wep.damage = 100;
                } else
                {
                    other.GetComponent<PillarProjectileScript>().StartAttack();
                }
                
                
                rb.AddForce(transform.forward * 1000f);
            }
        }


    }
}
