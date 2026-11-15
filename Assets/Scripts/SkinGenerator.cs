using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinGenerator : MonoBehaviour
{
    public int a;
    public GameObject[] Heads, Jackets, Jobs, Bodies, Torso, Tie, Arms;
    void Start()
    {
        a = (int)Random.Range(0.0f, Torso.Length);
        for (int n = 0; n < Torso.Length; n++)
        {
            if (n != a)
            {
                Destroy(Torso[n]);
            }
        }
        a = (int)Random.Range(0.0f, Heads.Length);
        for (int n = 0; n < Heads.Length; n++)
        {
            if(n != a)
            {
                Destroy(Heads[n]);
            }
        }
        a = (int)Random.Range(0.0f, 3.0f);
        if (a == 0)
        {
            a = (int)Random.Range(0.0f, 1.0f);
            Destroy(Jobs[a]);
            for (int n = 0; n < Tie.Length; n++)
            {
                Destroy(Tie[n]);
            }
            for (int n = 0; n < Bodies.Length; n++)
            {
                Destroy(Bodies[n]);
            }
        }
        else
        {
            Destroy(Jobs[0]);
            Destroy(Jobs[1]);
            a = (int)Random.Range(0.0f, Bodies.Length);
            for (int n = 0; n < Bodies.Length; n++)
            {
                if (n != a)
                {
                    Destroy(Bodies[n]);
                }
            }
            a = (int)Random.Range(0.0f, Tie.Length * 2);
            for (int n = 0; n < Tie.Length; n++)
            {
                if (n != a)
                {
                    Destroy(Tie[n]);
                }
            }
        }
        a = (int)Random.Range(0.0f, Jackets.Length * 2);
        for (int n = 0; n < Jackets.Length; n++)
        {
            if (n != a)
            {
                Destroy(Jackets[n]);
            }
        }
        if (a < Jackets.Length)
        {
            for (int n = 0; n < Arms.Length; n++)
            {
                    Destroy(Arms[n]);
            }
        }
    }
}
