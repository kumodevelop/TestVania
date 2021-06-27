using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBox : MonoBehaviour, IDamageable
{
    public int hitsToBreak;
    private Animator anim;
    private BoxCollider2D collider;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        collider = GetComponent<BoxCollider2D>();
    }

    public void Damage(float damaged)
    {
    }

    public void Destroying()
    {
        hitsToBreak--;
        if(hitsToBreak == 0)
        {
            anim.SetBool("break", true);
        }
        else
        {
            anim.SetBool("gothit", false);
            anim.SetBool("gothit", true);
            StartCoroutine(ResetAnim());
        }
    }

    private IEnumerator ResetAnim()
    {
        yield return new WaitForSeconds(0.2f);
        anim.SetBool("gothit", false);
    }
    public void DestroySelf()
    {
        Destroy(collider);
        Destroy(gameObject);
    }
}
