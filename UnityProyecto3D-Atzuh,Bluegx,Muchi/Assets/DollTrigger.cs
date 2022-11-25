using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DollTrigger : MonoBehaviour
{
    public Transform dollSpawnPoint;
    public GameObject doll;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Destroy(gameObject);
            Instantiate(doll, dollSpawnPoint.transform.position,dollSpawnPoint.transform.rotation);
        }
    }
}
