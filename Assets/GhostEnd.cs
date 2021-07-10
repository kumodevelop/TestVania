using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostEnd : MonoBehaviour
{
    public float disableTime;
    
    private void OnEnable()
    {
        StartCoroutine(disableGhostTime(disableTime));
    }

    IEnumerator disableGhostTime(float time)
    {
        yield return new WaitForSeconds(time);
        GhostPooling.GetInstance().ReturnToPool(this.gameObject);
    }

}
