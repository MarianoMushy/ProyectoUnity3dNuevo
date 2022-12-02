using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bellRing : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            AudioManager.Instance.Play("campana");
            Destroy(gameObject);
        }
    }
}
