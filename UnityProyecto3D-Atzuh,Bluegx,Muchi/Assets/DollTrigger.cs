using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DollTrigger : MonoBehaviour
{
    public Transform dollSpawnPoint;
    public GameObject doll;

    public static GameObject DollGlobal;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Destroy(gameObject);
           DollGlobal = Instantiate(doll, dollSpawnPoint.transform.position,dollSpawnPoint.transform.rotation);
        }
    }

    
}
