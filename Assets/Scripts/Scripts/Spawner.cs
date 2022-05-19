using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] objPrefab;
    int n;
    public float spawnTime = 0.1f;
    public float repeatRate = 1.0f;
    private float ySpawnPos = -3.5f;
    public float xSpawnPos;
 

    public void Awake()
    {
    
    }//Awake
    public void OnEnable()
    {
        //pick from array of prefabs
        n = Random.Range(0, objPrefab.Length);
        InvokeRepeating(nameof(SpawnObj), spawnTime, repeatRate);
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(SpawnObj));
    }

    public void SpawnObj() {
        //ranPos
        xSpawnPos = Random.Range(12, 20.5f);
        transform.position = new Vector3(xSpawnPos,ySpawnPos, 0);
        Instantiate(objPrefab[n], transform.position, Quaternion.identity);

    }//SpawnObj

   

    public void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Destroyer")
        {
            Destroy(gameObject);
        }
    }


}
