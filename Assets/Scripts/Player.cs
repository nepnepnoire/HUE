using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int control = 0;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("CanBePickedUp"))
        {
            collision.gameObject.SetActive(false);
            control = 1;
        }
        if (collision.gameObject.CompareTag("CanBeRed"))
        {
            collision.gameObject.SetActive(false);
            control = 2;
        }
    }
} 