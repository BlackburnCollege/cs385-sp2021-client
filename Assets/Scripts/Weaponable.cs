using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weaponable : MonoBehaviour
{
    public float damage = 1;

    public float attackTimeSec = 0.5f;

    public Characterable Owner { get; set; }

    public Collider[] CollidersActiveDeactive = new Collider[2];

    [SerializeField]
    private Player playerOwner;
    [SerializeField]
    private Animator animator;

    public virtual void StartAttack()
    {
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

    public void Pickup(Characterable pickUper)
    {
        Owner = pickUper;
        if(Owner is Player)
        {
            playerOwner = (Player)Owner;
            animator = playerOwner.GetComponentInChildren<Animator>();
            transform.SetParent(playerOwner.transform);
        }
    }
}
