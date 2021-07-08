using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackTest : MonoBehaviour
{
    DamageEffects callDamage = new DamageEffects();
    private void OnTriggerEnter2D(Collider2D collision)
    {
        IDamageable damaging = collision.GetComponent<IDamageable>();
        if (damaging != null && collision.tag=="Player")
        {
            callDamage.Damage(transform.parent.gameObject, collision.transform.gameObject, 25f);
        }
    }
}
