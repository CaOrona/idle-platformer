using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public float speed = 0.03f;
    public float distance = 0f;

    void FixedUpdate()
    {
        distance += speed;
    }
}
