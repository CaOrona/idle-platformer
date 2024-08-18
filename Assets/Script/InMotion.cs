using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class InMotion : MonoBehaviour
{
    public Manager manager
    {
        get => GetComponentInParent<Manager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += Vector3.left * manager.speed;
        if (gameObject.transform.position.x < -20) GameObject.Destroy(gameObject);

    }
}
