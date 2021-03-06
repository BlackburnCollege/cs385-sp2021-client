﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Weaponable : MonoBehaviour
{
    public float damage = 1;

    public float attackTimeSec = 0.5f;

    public Characterable Owner { get; set; }

    public Collider[] CollidersActiveDeactive = new Collider[2];

    [SerializeField]
    private Player playerOwner;
    [SerializeField]
    public Animator animator;

    public UnityEvent OnAttack = new UnityEvent();
    public virtual void StartAttack()
    {
        OnAttack.Invoke();
        if(animator != null)
        {
            animator.SetBool("attack", true);
            StartCoroutine(DisableAfterAttack());
        }

        foreach (Collider collider in CollidersActiveDeactive)
        {
            collider.enabled = true;
        }
    }

    public virtual void OnAttackEnd()
    {
        animator.SetBool("attack", false);
        foreach (Collider collider in CollidersActiveDeactive)
        {
            collider.enabled = false;
        }
    }

    IEnumerator DisableAfterAttack()
    {
        yield return new WaitForSeconds(attackTimeSec);
        OnAttackEnd();
        yield return true;
    }

    public virtual void DealDamage(Characterable target)
    {
        target.Health -= damage;

    }

    public virtual void Pickup(Characterable pickUper)
    {
        //test
        Owner = pickUper;
        if(Owner is Player)
        {
            playerOwner = (Player)Owner;
            animator = playerOwner.GetComponentInChildren<Animator>();
            transform.SetParent(playerOwner.transform);
        }
    }
}
