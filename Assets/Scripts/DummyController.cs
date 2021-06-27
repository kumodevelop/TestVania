using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyController : MonoBehaviour, IDamageable
{
    private Animator anim;

    
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void Damage(float damaged)
    {
        Debug.Log("Tomei " + damaged + " de dano!");
    }

    public void Destroying()
    {
    }
}
