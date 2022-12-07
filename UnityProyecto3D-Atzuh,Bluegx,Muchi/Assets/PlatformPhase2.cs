using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPhase2 : MonoBehaviour
{
    public Rigidbody platformRB;
    public Transform[] platformPositions;
    public Transform downPos;
    public float platformSpeed;

    private int actualPosition = 0;
    private int nextPosition = 1;

    private bool moveToTheNext = true;
    public float waitTime;

    public bool DiezSegundos = true;
    public bool CincoSegundos = true;


    [SerializeField] private Vector3 _rotation;
    [SerializeField] private float _speed;
    bool up = true;

    void Update()
    {
        //MovePlatform();
        //MovePlatDown();

        if (moveToTheNext)
        {
            MovePlatform();
            MovePlatDown();
        }
        else
        {
            Rotar();
        }
    }

    void MovePlatform()
    {
        if (DiezSegundos)
        {
            StartCoroutine(DiezSegundosRutina());

            if (moveToTheNext)
            {

                StopCoroutine(waitForMove(0));
                platformRB.MovePosition(Vector3.MoveTowards(platformRB.position, platformPositions[nextPosition].position, platformSpeed * Time.deltaTime));
            }

            if (Vector3.Distance(platformRB.position, platformPositions[nextPosition].position) <= 0)
            {
                //nextPosition = Random.Range(0, platformPositions.Length);
                StartCoroutine(waitForMove(waitTime));
                actualPosition = nextPosition;
                nextPosition++;

                if (nextPosition > platformPositions.Length - 1)
                {
                    nextPosition = 0;
                }
            }
        }
    }

    void MovePlatDown()
    {
        if (DiezSegundos == false)
        {
            if (CincoSegundos == true)
            {

                StartCoroutine(CincoSegundosRutina());

            }
        }
    }

    public void Rotar()
    {
        if (up)
        {
            //transform.Rotate(_rotation * _speed * Time.deltaTime);
            transform.Rotate(_rotation * -1 * _speed * Time.deltaTime);
            StartCoroutine(rutinaEspada());
        }
        else
        {
            StartCoroutine(rutinaEspada2());
            transform.Rotate(_rotation * _speed * Time.deltaTime);
            //transform.Rotate(_rotation * -1 * _speed * Time.deltaTime);
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

    IEnumerator waitForMove(float time)
    {

        moveToTheNext = false;
        yield return new WaitForSeconds(time);
        moveToTheNext = true;
    }

    IEnumerator DiezSegundosRutina()
    {
        yield return new WaitForSeconds(10f);
        DiezSegundos = false;
        CincoSegundos = true;

    }

    IEnumerator CincoSegundosRutina()
    {
        platformRB.MovePosition(Vector3.MoveTowards(platformRB.position, downPos.position, platformSpeed * Time.deltaTime));
        yield return new WaitForSeconds(10f);
        CincoSegundos = false;
        DiezSegundos = true;
    }
}
