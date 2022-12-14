using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPhase2 : MonoBehaviour
{
    public Rigidbody platformRB;
    public Transform[] platformPositions;
    public float platformSpeed;

    private int actualPosition = 0;
    private int nextPosition = 1;

    private bool moveToTheNext = true;
    public float waitTime;

    [SerializeField] private Vector3 _rotation;
    [SerializeField] private float _speed;
    bool up = true;

    void Update()
    {
        if (moveToTheNext)
        {
            MovePlatform();
        }
        else
        {
            Rotar();
        }
    }

    void MovePlatform()
    {
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

    public void Rotar()
    {
        if (up)
        {
            transform.Rotate(_rotation * -1 * _speed * Time.deltaTime);
            StartCoroutine(rutinaEspada());
        }
        else
        {
            StartCoroutine(rutinaEspada2());
            transform.Rotate(_rotation * _speed * Time.deltaTime);
        }
    }

    IEnumerator rutinaEspada()
    {
        up = true;
        yield return new WaitForSeconds(3f);
        up = false;
    }

    IEnumerator rutinaEspada2()
    {
        up = false;
        yield return new WaitForSeconds(3f);
        up = true;
    }

    IEnumerator waitForMove(float time)
    {

        moveToTheNext = false;
        yield return new WaitForSeconds(time);
        moveToTheNext = true;
    }
}
