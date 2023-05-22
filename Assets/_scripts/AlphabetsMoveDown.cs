using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlphabetsMoveDown : MonoBehaviour
{

    private float speed = 6f;
    float X;
  
   
    void Start()
    {
        X = Random.Range(-.01f, .01f);
        Destroy(gameObject, 4f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       
        
       // float Z = Random.Range(-3, 3);
      //  this.gameObject.transform.position += new Vector3(X, -0.2f, 0)* speed*Time.deltaTime;
       
    }
}
