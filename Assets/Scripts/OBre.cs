using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OBre : MonoBehaviour
{
    private GameObject bluerock;
    private GameObject redrock;
    private int control;
    private GameObject con;
    // Start is called before the first frame update
    void Start()
    {
        bluerock = GameObject.FindGameObjectWithTag("BlueRock");
        redrock = GameObject.FindGameObjectWithTag("RedRock");
    }

    // Update is called once per frame
    void Update()
    {
        con = GameObject.FindGameObjectWithTag("Player");
        control =con.GetComponent<Player>().control;
        if (control >= 1)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                bluerock.SetActive(false);
                redrock.SetActive(true);
            }
        }
        if (control > 1)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                bluerock.SetActive(true);
                redrock.SetActive(false);
            }
        }
    }
}
