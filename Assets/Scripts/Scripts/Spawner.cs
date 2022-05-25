using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] objPrefab;
    int n;
    public float spawnTime = 0.1f;
    public float repeatRate = 1.0f;
    public float ySpawnPos = -1.4f;
    public float xSpawnPos;
    public Vector3 offSet;

    public float maxX = 30.0f;
    public float minX = 12.0f;
    
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
        xSpawnPos = Random.Range(minX, maxX);
        offSet = new Vector3(xSpawnPos, 0, 0);
        Instantiate(objPrefab[n], transform.position + offSet , Quaternion.identity);

    }//SpawnObj

}
