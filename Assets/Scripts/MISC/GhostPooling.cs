using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostPooling : MonoBehaviour
{
    public GameObject[] pooling = null;
    public GameObject prefab = null;
    public int maxObjects = 0;

    private static GhostPooling uniqueInstance = null;
    public static GhostPooling GetInstance()
    {
        return uniqueInstance;
    }

    public void Create(Vector3 position, Quaternion rotation,SpriteRenderer playerAnim)
    {
        for (int i = 0; i < maxObjects; i++)
        {
            if (!pooling[i].activeSelf)
            {
                if (playerAnim != null)
                pooling[i].GetComponent<SpriteRenderer>().sprite = playerAnim.sprite;
                pooling[i].SetActive(true);
                pooling[i].transform.position = position;
                pooling[i].transform.rotation = rotation;               
                break;
            }
        }
    }

    public void ReturnToPool(GameObject poolObject)
    {
        poolObject.SetActive(false);
    }



    private void Awake()
    {
        if (uniqueInstance == null)
        {
            uniqueInstance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        //maxObjects = GameManager.GetInstance().getLimiteInimigos();
        //Debug.Log(GameManager.GetInstance().getLimiteInimigos().ToString());
        pooling = new GameObject[maxObjects];
        for (int i = 0; i < maxObjects; i++)
        {        
            pooling[i] = GameObject.Instantiate<GameObject>(prefab);
            pooling[i].SetActive(false);

        }

    }







}
