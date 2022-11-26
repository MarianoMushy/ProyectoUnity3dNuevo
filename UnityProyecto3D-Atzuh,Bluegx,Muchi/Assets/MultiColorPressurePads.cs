using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiColorPressurePads : MonoBehaviour
{
    public GameObject puertaRoja;

    public Animator animpuertaRoja;

    




    private void Start()
    {
        animpuertaRoja = puertaRoja.GetComponent<Animator>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "YellowCube")
        {
            Transform box = other.GetComponent<Transform>();

            box.GetComponent<Rigidbody>().isKinematic = true;
            box.GetComponent<Renderer>().material.color = Color.green;
            Destroy(box.gameObject, 2f);

           GameManager.instance.YellowCube = true;
           Debug.Log("yellow");

        }

        if (other.tag == "OrangeCube")
        {
            Transform box = other.GetComponent<Transform>();

            box.GetComponent<Rigidbody>().isKinematic = true;
            box.GetComponent<Renderer>().material.color = Color.green;
            Destroy(box.gameObject, 2f);
            Debug.Log("orange");

            GameManager.instance.OrangeCube = true;

        }

        if (other.tag == "DarkBlueCube")
        {
            Transform box = other.GetComponent<Transform>();

            box.GetComponent<Rigidbody>().isKinematic = true;
            box.GetComponent<Renderer>().material.color = Color.green;
            Destroy(box.gameObject, 2f);

            Debug.Log("dark");

            GameManager.instance.DarkBlueCube = true;
        }

    }

    private void Update()
    {
        if(GameManager.instance.YellowCube && GameManager.instance.OrangeCube && GameManager.instance.DarkBlueCube)
        {
            //puertaRoja.SetActive(false);
            Debug.Log("puerta");
            animpuertaRoja.SetTrigger("PuertaRojaDown");
            Destroy(DollTrigger.DollGlobal);
        }
    }
}
