using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobSpawner : MonoBehaviour
{
    public Manager manager
    {
        get => GetComponentInParent<Manager>();
    }
    public GameObject monster;
    void Start()
    {
        Instantiate(monster, transform.position, transform.rotation, manager.gameObject.transform);
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0)) Instantiate(monster, transform.position, transform.rotation, gameObject.transform);

    }

}
