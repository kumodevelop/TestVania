using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBarScript : MonoBehaviour
{
    private GameObject playerObj;
    private GeneralData playerHP;
    public Slider hpBar;
    public bool test;
    public float tstnumber;
    // Start is called before the first frame update
    void Start()
    {
        playerObj = GameObject.Find("Player");
        hpBar = GetComponent<Slider>();
        playerHP = playerObj.GetComponent<GeneralData>();
    }

    // Update is called once per frame
    void Update()
    {
        if(test)
              hpBar.value = Mathf.Lerp(0,playerHP.hp/playerHP.fullhp*100, 0.01f);
           // tstnumber = Mathf.Lerp(0,playerHP.hp/playerHP.fullhp*100, 0.01f);
    }
}
