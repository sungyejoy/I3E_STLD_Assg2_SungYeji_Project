using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    //public float fireRate = 15f;
    public float impactForce = 50f;

    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    // public GameObject impactEffect;

    private float nextTimeToFire = 0f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) //&& Time.time >= nextTimeToFire)
        {
            //nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
    }

    void Shoot()
    {
        muzzleFlash.Play();

        RaycastHit hit;
        
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            fireGolem FireGolem = hit.transform.GetComponent<fireGolem>();

            if(FireGolem != null)
            {
                FireGolem.TakeDamage(damage);
            }

            if(hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }

            // Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));

        }
    }

}
