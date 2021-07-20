using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    public float delay;
    public float delaySeconds;
    public float destroyGhostTime;
    public bool activeGhost = false;
    
    // Start is called before the first frame update
    void Start()
    {
        delaySeconds = delay;
    }

    // Update is called once per frame
    void Update()
    {
        if (activeGhost)
        {
            if (delaySeconds > 0)
            {
                delaySeconds -= Time.deltaTime;
            }
            else
            {
                GhostPooling.GetInstance().Create(transform.position, transform.rotation, GetComponent<SpriteRenderer>());
                //GameObject currentGhost = Instantiate(GhostObj, transform.position, transform.rotation);
               // Sprite currentSprite = GetComponent<SpriteRenderer>().sprite;
                //currentGhost.GetComponent<SpriteRenderer>().sprite = currentSprite;
               //currentGhost.transform.localRotation = transform.localRotation;
                delaySeconds = delay;
                //GhostPooling.GetInstance().ReturnToPool(this.gameObject);
                //Destroy(currentGhost, destroyGhostTime);

            }
        }
    }
}
