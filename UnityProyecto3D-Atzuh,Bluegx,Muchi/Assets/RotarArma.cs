using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotarArma : MonoBehaviour
{
    float x;

    float min = 270, max = 280;

    float eulerAngX;

    [SerializeField] private Vector3 _rotation;
    [SerializeField] private float _speed;

    bool up = true;

    private void Update()
    {
        Mathf.Clamp(x, min, max);

        eulerAngX = transform.localEulerAngles.x;

        //Debug.Log(eulerAngX);
        Debug.Log(_rotation);

        if (up)
        {
            transform.Rotate(_rotation * _speed * Time.deltaTime);
            StartCoroutine(rutinaEspada());
        }
        else
        {
            StartCoroutine(rutinaEspada2());
            transform.Rotate(_rotation * -1* _speed * Time.deltaTime);
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
