using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAttack : MonoBehaviour
{
    DamageEffects callDamage = new DamageEffects();
    private Animator anim;

    private void Awake()
    {
        anim = transform.parent.GetComponent<Animator>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        IDamageable damaging = collision.GetComponent<IDamageable>();
        if (damaging != null)
        {
            if (!anim.GetBool("attack3"))
            {
                callDamage.Damage(transform.parent.gameObject, collision.transform.gameObject, 25f);
            }
            else
            {
                callDamage.Damage(transform.parent.gameObject, collision.transform.gameObject, 40f);
            }
        }       
    }
}
