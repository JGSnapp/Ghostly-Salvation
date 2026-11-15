using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanScript : MonoBehaviour
{
    public GameObject Part2, Part1, Body_h, Body_d, Body_p;
    public Transform BodyOriginal, BoneSecond, rotatehelper;
    public GameObject[] Bone1, Bone2, t;
    public Transform[] c, p, d, h;
    public Vector3 vec;
    public bool a = true, b = false, f = false, front, up = false;
    public float speed, speedslow, p_dis, d_dis, h_dis;
    public int l = 0, k = 0;

    public void FixedUpdate()
    {


        if (a)
        {
            if (b)
            {
                for (int n = 0; n < 13; n++)
                {

                    if (n < 9)
                    {
                        vec = c[n].position;
                        t[n].transform.position = vec;
                    }
                    Bone1[n].GetComponent<Rigidbody2D>().gravityScale = 0;

                }
                if (rotatehelper.position.x - BodyOriginal.transform.position.x < BodyOriginal.transform.position.x - rotatehelper.position.x)
                {
                    front = true;
                }
                else
                {
                    front = false;
                }
                Part1.GetComponent<Balance>().enabled = false;
                b = false;
                Body_d.transform.position = new Vector3(BodyOriginal.transform.position.x, Body_d.transform.position.y, Body_d.transform.position.z);
                Body_p.transform.position = new Vector3(BodyOriginal.transform.position.x, Body_p.transform.position.y, Body_p.transform.position.z);
                Body_h.transform.position = new Vector3(BodyOriginal.transform.position.x, Body_h.transform.position.y, Body_h.transform.position.z);
            }
            if (up)
            {
                if (f)
                {
                    if (front)
                    {
                        for (int n = 0; n < 9; n++)
                        {
                            t[n].transform.position = Vector3.Lerp(t[n].transform.position, p[n].transform.position, Time.deltaTime * speedslow);
                            t[n].transform.rotation = Quaternion.Lerp(t[n].transform.rotation, p[n].transform.rotation, Time.deltaTime * speedslow);
                            if (n == 8)
                            {
                                if (t[l].transform.position.x > p[l].transform.position.x - 0.2f && t[l].transform.position.x < p[l].transform.position.x + 0.2f)
                                {
                                    if (t[l].transform.position.y > p[l].transform.position.y - 0.2f && t[l].transform.position.y < p[l].transform.position.y + 0.2f)
                                    {
                                        l = l + 1;
                                        if (l == 9)
                                        {
                                            Part2.transform.position = new Vector3(BoneSecond.transform.position.x + p_dis, Part2.transform.position.y, Part2.transform.position.z);
                                            Part2.GetComponent<Animator>().enabled = true;
                                            Part2.GetComponent<Animator>().Play("UpFront");
                                            l = 0;
                                            up = false;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        for (int n = 0; n < 9; n++)
                        {
                            t[n].transform.position = Vector3.Lerp(t[n].transform.position, d[n].transform.position, Time.deltaTime * speedslow);
                            t[n].transform.rotation = Quaternion.Lerp(t[n].transform.rotation, d[n].transform.rotation, Time.deltaTime * speedslow);
                            if (n == 8)
                            {
                                if (t[l].transform.position.x > d[l].transform.position.x - 0.2f && t[l].transform.position.x < d[l].transform.position.x + 0.2f)
                                {
                                    if (t[l].transform.position.y > d[l].transform.position.y - 0.2f && t[l].transform.position.y < d[l].transform.position.y + 0.2f)
                                    {
                                        l = l + 1;
                                        if (l == 9)
                                        {
                                            Part2.transform.position = new Vector3(BoneSecond.transform.position.x + d_dis, Part2.transform.position.y, Part2.transform.position.z);
                                            Part2.GetComponent<Animator>().enabled = true;
                                            Part2.GetComponent<Animator>().Play("UpBack");
                                            l = 0;
                                            up = false;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    for (int n = 0; n < 9; n++)
                    {
                        t[n].transform.position = Vector3.Lerp(t[n].transform.position, h[n].transform.position, Time.deltaTime * speedslow);
                        t[n].transform.rotation = Quaternion.Lerp(t[n].transform.rotation, h[n].transform.rotation, Time.deltaTime * speedslow);
                        if (n == 8)
                        {
                            if (t[l].transform.position.x > h[l].transform.position.x - 0.2f && t[l].transform.position.x < h[l].transform.position.x + 0.2f)
                            {
                                if (t[l].transform.position.y > h[l].transform.position.y - 0.2f && t[l].transform.position.y < h[l].transform.position.y + 0.2f)
                                {
                                    l = l + 1;
                                    if (l == 9)
                                    {
                                        Part2.transform.position = new Vector3(BoneSecond.transform.position.x + h_dis, Part2.transform.position.y, Part2.transform.position.z);
                                        Part2.GetComponent<Animator>().enabled = true;
                                        Part2.GetComponent<Animator>().Play("Idle");
                                        l = 0;
                                        up = false;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            for (int n = 0; n < 13; n++)
            {
                Bone1[n].transform.position = Vector3.Lerp(Bone1[n].transform.position, Bone2[n].transform.position, Time.deltaTime * speed);
                Bone1[n].transform.rotation = Quaternion.Lerp(Bone1[n].transform.rotation, Bone2[n].transform.rotation, Time.deltaTime * speed);
            }
        }
        else
        {
            if (!b)
            {
                Part2.GetComponent<Animator>().enabled = false;
                for (int n = 0; n < 13; n++)
                {
                    Bone1[n].GetComponent<Rigidbody2D>().gravityScale = 1;
                }
                if (!f)
                    Part1.GetComponent<Balance>().enabled = true;
                up = true;
                b = true;
            }
            if (!f)
            {
                Invoke("SampleScene", 1.0f);
                if (k > 20)
                {
                    k = 0;
                    a = true;
                }
                else
                {
                    k = k + 1;
                }
            }
            else
            {
                Invoke("SampleScene", 1.0f);
                if (k > 70)
                {
                    k = 0;
                    a = true;
                }
                else
                {
                    k = k + 1;
                }
            }
        }
    }
}
