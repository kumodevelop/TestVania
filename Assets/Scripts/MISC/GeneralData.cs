using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralData : MonoBehaviour
{
    public float hp;
    public float fullhp;
    public float mp;
    public float speed;
    public float jumpspeed;
    public float dashingTime;
    public float dashForce;
    public bool isBox;
    [HideInInspector]
    public DamageEffects.Effects currentBuff;
    
}
