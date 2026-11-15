using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoneTeller : MonoBehaviour
{
    public GameObject H;
    public float speed;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "DJ")
        {
            if (H.GetComponent<HumanScript>().a)
            {
                H.GetComponent<HumanScript>().a = false;
                speed = collision.gameObject.GetComponent<Rigidbody2D>().velocity.magnitude;
                if (speed > 2)
                    H.GetComponent<HumanScript>().f = true;
                else
                    H.GetComponent<HumanScript>().f = false;
            }
            else
                H.GetComponent<HumanScript>().k = 0;
        }
    }
}
