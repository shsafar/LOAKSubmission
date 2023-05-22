using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour
{


    private void OnTriggerEnter(Collider other)
    {
       // Destroy(other.gameObject);
      //  Debug.Log(other.transform.name);
        WordsMatcher.Instance.CheckMisssed(other);
    }

}
