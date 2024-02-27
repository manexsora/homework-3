using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class playerWeapon : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float bulletSpeed = 30;
    public float lifeTime = 3;
    private bool fireGun =false;
    private float fireCooldown = 1f; 
    private float lastFireTime;

    void Start()    {
        
    }

    void Update()
    {
        if (Time.time - lastFireTime > fireCooldown && fireGun)
        {
            fire(); // Fire the weapon
            lastFireTime = Time.time; // Update the time of the last shot
        }
    }
    
   
    internal void fire()
    {
        if (fireGun)
        {
            GameObject bullet = Instantiate(bulletPrefab);

            //Physics.IgnoreCollision(bullet.GetComponent<Collider>(),
            //       bulletSpawn.parent.GetComponent<Collider>());

            bullet.transform.position = bulletSpawn.position;

            Vector3 rotation = bullet.transform.rotation.eulerAngles;

            bullet.transform.rotation = Quaternion.Euler(rotation.x, transform.eulerAngles.y, rotation.z);

            bullet.GetComponent<Rigidbody>().AddForce(bulletSpawn.forward * bulletSpeed, ForceMode.Impulse);

            StartCoroutine(DestroyBulletAfterTime(bullet, lifeTime));
            fireGun = false;
        }

    }
    public void setFiregun(bool b)
    {
        fireGun = b;
    }
    private IEnumerator DestroyBulletAfterTime(GameObject bullet, float delay)
    {
        yield return new WaitForSeconds(delay);

        Destroy(bullet);
    }
}
