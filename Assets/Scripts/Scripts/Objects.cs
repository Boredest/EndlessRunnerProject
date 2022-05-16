using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objects : MonoBehaviour
{

    public float speed = 5.0f;
    public float leftBound;
    public float offset = -1.0f;
  
    private void Start()
    {
        leftBound = Camera.main.ScreenToWorldPoint(Vector3.zero).x - offset;
    }//Start
    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

        if(transform.position.x < leftBound)
        {
            Destroy(gameObject);
        }
    }//Update
}
