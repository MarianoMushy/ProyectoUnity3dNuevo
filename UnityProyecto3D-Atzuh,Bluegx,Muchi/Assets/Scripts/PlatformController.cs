using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public Rigidbody platformRB;
    public Transform[] platformPositions;
    public float platformSpeed;

    private int actualPosition = 0;
    private int nextPosition = 1;

    public bool moveToTheNext = true;
    public float waitTime;

    void Update()
    {
        MovePlatform();
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

            if(nextPosition > platformPositions.Length -1)
            {
                nextPosition = 0;
            }
        }
    }
    IEnumerator waitForMove(float time)
    {
        moveToTheNext = false;
        yield return new WaitForSeconds(time);
        moveToTheNext = true;
    }
}
