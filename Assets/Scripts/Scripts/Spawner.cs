using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] objPrefab;
    public float spawnPos;
    public float offset = 5.0f;
    int n;
    public float spawnRate = 1f;
    public float delayTime = 2.0f;

    private float ySpawnPos = -3.5f;
    public float xSpawnPos;
 

    public void Awake()
    {
    
    }//Awake
    public void OnEnable()
    {
        n = Random.Range(0, objPrefab.Length);
        InvokeRepeating(nameof(SpawnObj), spawnRate, delayTime);
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(SpawnObj));
    }

    public void SpawnObj() {
        //ranPos
       // xSpawnPos = Random.Range(12, 15);
       // transform.position = new Vector3(xSpawnPos,(float)-3.5, 0);
  
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
