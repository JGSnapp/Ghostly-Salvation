using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balance : MonoBehaviour
{
    public Muscle[] muscles;
    public void FixedUpdate()
    {
        foreach (Muscle muscle in muscles)
        {
            muscle.ActivateMuscle();
        }
    }
}
[System.Serializable]
public class Muscle
{
    public Rigidbody2D bone;
    public float restRotation;
    public float force;
    public void ActivateMuscle()
    {
        bone.MoveRotation(Mathf.LerpAngle(bone.rotation, restRotation, force * Time.deltaTime));
    }
}

