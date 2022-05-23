using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objects : MonoBehaviour
{
    
    public float speed = 5.0f;
    public float leftBound;
    public float offset = -1.0f;
    public float distance = 2.0f;
    public Vector3 castOffset;
    public Vector3 startCast;
    public Vector3 endCast;
    
   
    private void Start()
    {

        leftBound = Camera.main.ScreenToWorldPoint(Vector3.zero).x - offset;
        castOffset = new Vector3(0.5f , 0f, 0);
        endCast = new Vector3(2f, 0, 0);
    }//Start
    void Update()
    {

        CheckCol();

        
    }//Update

    public void CheckCol()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

        if (transform.position.x < leftBound - offset)
        {
            Destroy(gameObject);
        }

        startCast = transform.position + castOffset;
        RaycastHit2D checkCol = Physics2D.Raycast(startCast + castOffset, Vector2.right, distance);
        Debug.DrawRay(startCast + castOffset, Vector2.right, Color.red);


        if (checkCol.collider != null)
        {

            if (checkCol.collider.name == "Boxes(Clone)")
            {
                Debug.Log(checkCol.collider.name);
                Destroy(gameObject);


            }
        }
    }//CheckCol

   
  


}
