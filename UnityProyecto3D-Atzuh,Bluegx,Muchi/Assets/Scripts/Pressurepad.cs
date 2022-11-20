using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pressurepad : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Cube")
        {
            Transform box = other.GetComponent<Transform>();
            
            box.GetComponent<Rigidbody>().isKinematic = true;
            box.GetComponent<Renderer>().material.color = Color.green;
            Destroy(box.gameObject, 2f);
           
        }
    }
}
