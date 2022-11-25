using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiColorPressurePads : MonoBehaviour
{
    //public GameObject puerta;

    //public Animator animpuerta;


    private void Start()
    {
        //animpuerta = puerta.GetComponent<Animator>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "YellowCube")
        {
            Transform box = other.GetComponent<Transform>();

            box.GetComponent<Rigidbody>().isKinematic = true;
            box.GetComponent<Renderer>().material.color = Color.green;
            Destroy(box.gameObject, 2f);

            //puerta.SetActive(false);
            //animpuerta.SetTrigger("puertaverde");

        }

    }
}
