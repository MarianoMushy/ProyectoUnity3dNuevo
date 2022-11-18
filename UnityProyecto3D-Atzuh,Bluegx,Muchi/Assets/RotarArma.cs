using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotarArma : MonoBehaviour
{
    [SerializeField] private Vector3 _rotation;
    [SerializeField] private float _speed;

    bool up = true;

    private void Update()
    {

        Rotar();
    }


    public void Rotar()
    {
        if (up)
        {
            transform.Rotate(_rotation * _speed * Time.deltaTime);
            StartCoroutine(rutinaEspada());
        }
        else
        {
            StartCoroutine(rutinaEspada2());
            transform.Rotate(_rotation * -1 * _speed * Time.deltaTime);
        }
    }

    IEnumerator rutinaEspada()
    {
        up = true;
        yield return new WaitForSeconds(.5f);
        up = false;
    }


    IEnumerator rutinaEspada2()
    {
        up = false;
        yield return new WaitForSeconds(.5f);
        up = true;
    }

}
