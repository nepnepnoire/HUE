using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBGB : MonoBehaviour
{
    public int control;
    private GameObject red;
    private GameObject blue;
    private GameObject purple;
    private GameObject con;
    void Start()
    {
        blue = GameObject.FindGameObjectWithTag("Blue");
        red = GameObject.FindGameObjectWithTag("Red");
        purple = GameObject.FindGameObjectWithTag("Purple");
    }

    // Update is called once per frame
    void Update()
    {
        con = GameObject.FindGameObjectWithTag("Player");
        control = con.GetComponent<Player>().control;
        if (control >= 1)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                purple.SetActive(false);
                blue.SetActive(true);
                red.SetActive(false);
            }
        }
        if (control > 1)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                purple.SetActive(false);
                red.SetActive(true);
                blue.SetActive(false);
            }
        }
    }
}
