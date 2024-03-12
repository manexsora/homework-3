using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Pistol : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float bulletSpeed = 30;
    public float lifeTime = 3;
    public float fireCooldown = 0.5f;

    private bool fireGun = false;
    private float lastFireTime;
    private XRGrabInteractable grabInteractable;
    private bool grabbed = false;
    private BoxCollider boxColider;


    void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();

        boxColider = GetComponent<BoxCollider>();

        grabInteractable.onSelectEntered.AddListener(OnGrab);
        grabInteractable.onSelectExited.AddListener(OnRelease);
    }

    void Update()
    {
        if (Time.time - lastFireTime > fireCooldown && fireGun && grabbed)
        {
            fire(); // Fire the weapon
            lastFireTime = Time.time; // Update the time of the last shot
        }
    }

    internal void fire()
    {
        //GameObject bullet = Instantiate(bulletPrefab);
        //
        //bullet.transform.position = bulletSpawn.position;
        //
        //Vector3 rotation = bullet.transform.rotation.eulerAngles;
        //
        //bullet.transform.rotation = Quaternion.Euler(rotation.x, transform.eulerAngles.y, rotation.z);
        //
        //bullet.GetComponent<Rigidbody>().AddForce(bulletSpawn.forward * bulletSpeed, ForceMode.Impulse);
        //
        //StartCoroutine(DestroyBulletAfterTime(bullet, lifeTime));
        //fireGun = false;
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, Quaternion.identity);

        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            float velocity = bulletSpeed;
            rb.velocity = bulletSpawn.forward * velocity;
        }
        else
        {
            Debug.LogWarning("Plate prefab does not have a Rigidbody!");
        }
        StartCoroutine(DestroyBulletAfterTime(bullet, lifeTime));
        fireGun = false;
    }

    private IEnumerator DestroyBulletAfterTime(GameObject bullet, float delay)
    {
        yield return new WaitForSeconds(delay);

        Destroy(bullet);
    }

    public void setFiregun(bool b)
    {
        fireGun = b;
    }

    void OnGrab(XRBaseInteractor interactor)
    {
        grabbed = true;
        boxColider.enabled = false;
        interactor.transform.GetChild(0).gameObject.SetActive(false);
    }

    void OnRelease(XRBaseInteractor interactor)
    {
        grabbed = false;
        boxColider.enabled = true;
        interactor.transform.GetChild(0).gameObject.SetActive(true);
    }
}
