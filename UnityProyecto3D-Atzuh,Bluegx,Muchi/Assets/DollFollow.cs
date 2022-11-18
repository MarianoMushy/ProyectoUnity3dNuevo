using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DollFollow : MonoBehaviour
{
    private Transform player;

    private Rigidbody theRB;

    public float speed;

    private bool isNeer;

    public float radius;

    public LayerMask whatIsPlayer;

    //[SerializeField] private Transform target;

    [SerializeField] private int x;
    [SerializeField] private int y;
    [SerializeField] private int z;





    private void Start()
    {
        theRB = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        //isNeer = Physics2D.OverlapCircle(this.transform.position, radius, whatIsPlayer);

        transform.LookAt(player);
        transform.Rotate(x, y, x);


        player = GameObject.FindGameObjectWithTag("Player").transform;

        if (player == null)
        {
            return;
        }



        Vector3 target = new Vector3(player.position.x, player.position.y, player.position.z);

        Vector3 newPos = Vector3.MoveTowards(theRB.position, target, speed * Time.deltaTime);

        theRB.MovePosition(newPos);


    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(this.transform.position, radius);
    }

}
