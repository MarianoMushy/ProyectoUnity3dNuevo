using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformControllerBoss : MonoBehaviour
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

    public GameObject bomba;
    public Transform bombspawn;
    private bool bomboaBool = true;




    void Update()
    {
        MovePlatform();
        MovePlatDown();
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
                
                if (bomboaBool)
                {
                    instanciarBomba();
                    bomboaBool = false;
                }
                

                nextPosition = Random.Range(0, platformPositions.Length);
                StartCoroutine(waitForMove(waitTime));
                actualPosition = nextPosition;
                //nextPosition++;

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


    IEnumerator waitForMove(float time)
    {
        
        moveToTheNext = false;
        yield return new WaitForSeconds(time);
        bomboaBool = true;
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

    void instanciarBomba()
    {
        Instantiate(bomba, bombspawn.position, bombspawn.rotation);
    }

}
