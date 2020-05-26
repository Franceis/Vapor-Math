using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platforms : MonoBehaviour
{
    public float vel;
    public Transform pontoA, pontoB;

    public static bool ON;

    void Update()
    {
        float step = vel * Time.deltaTime;

        if (ON)
        {
            transform.position = Vector3.MoveTowards(transform.position, pontoB.position, step);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, pontoA.position, step);
        }
        
    }
}
