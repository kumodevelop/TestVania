using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager gm;
    private float playerHP;

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

    // Update is called once per frame
    void Update()
    {
        
    }
}
