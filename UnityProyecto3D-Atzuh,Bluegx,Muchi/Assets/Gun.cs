using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10;

    public float time;
    public float repeatRate;

    public GameObject cubePrefab;
    public float cubeSpeed;

    public float Cubetime;
    public float CuberepeatRate;


    private void Start()
    {
        InvokeRepeating("Shoot", time, repeatRate);

        InvokeRepeating("ShootBlock", Cubetime, CuberepeatRate);
    }


    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        //    bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;
        //}
    }

    public void Shoot()
    {
            var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.up * bulletSpeed;
    }

    public void ShootBlock()
    {
        var bullet = Instantiate(cubePrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.up * cubeSpeed;
    }

}
