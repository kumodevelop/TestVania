using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEffects
{
    public enum Effects
    {
        normal,
        fire,
        poison,
        ice,
        curse
    }

    public void Damage(GameObject getDamage,GameObject receiveDamage,float amount)
    {
        GeneralData damaging = getDamage.GetComponent<GeneralData>();
        GeneralData hurting = receiveDamage.GetComponent<GeneralData>();
        if (damaging.currentBuff == Effects.normal && !hurting.isBox)
        {
            receiveDamage.GetComponent<IDamageable>().Damage(amount);
        }
        else if(hurting.isBox)
        {
            receiveDamage.GetComponent<IDamageable>().Destroying();
        }
     
    }
    
}
