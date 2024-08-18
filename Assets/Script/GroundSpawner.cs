using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameObject firstGround;
    public float spacing = 0.9f;
    public float holeProbability = 0.05f;
    public Vector2 holeSizeRange = new Vector2(1.2f, 4.2f);
    public float horizontalSparsing = 0f;
    public bool fixedYPosition = false;

    private float yPosition;


    public Manager manager
    {
        get => GetComponentInParent<Manager>();
    }

    private void Start()
    {
        yPosition = firstGround.transform.position.y;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if(  firstGround.transform.position.x < this.transform.position.x)
        {
            SpawnTile();
        }     

    }

    void SpawnTile()
    {
        //if (Random.value < 0.18) lastGround.transform.position += Vector3.up * (Random.value * 1.1f - .5f);
        var holing = Random.value < holeProbability ? Random.value*(holeSizeRange.y-holeSizeRange.x)+holeSizeRange.x : 0;
        var horizontal = Random.value * horizontalSparsing - horizontalSparsing / 2;
        firstGround = Instantiate(firstGround, firstGround.transform.position + new Vector3(spacing+holing,horizontalSparsing,0), this.transform.rotation, manager.gameObject.transform);
        if (fixedYPosition) firstGround.transform.position = new Vector3(firstGround.transform.position.x, yPosition, firstGround.transform.position.z);
        firstGround.name = "dirt"; 

  
    
        
    }
}
