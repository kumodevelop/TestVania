using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager gm;
    public float playerHP = 100;

    public static GameManager GetInstance()
    {
        return gm;
    }
    // Start is called before the first frame update
    void Awake()
    {
        if (gm == null)
        {
            gm = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void setPlayerHP(float newHP)
    {
        playerHP = newHP;
    }
    public float getPlayerHP()
    {
        return playerHP;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
