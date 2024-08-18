using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Monster : MonoBehaviour
{
    

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.GetComponent<Collider2D>().IsTouchingLayers(LayerMask.GetMask("Attack"))) Destroy(gameObject);
    }
}
