/*
 * Author:  Sung Yeji
 * Date: 15/06/2024
 * Description: This script is for the Gun on the first person 
 */

using UnityEngine;

public class Gun : MonoBehaviour
{
    /// <summary>
    /// The amount of damage the gun does per shoot is 10
    /// </summary>
    public int damage = 10;

    /// <summary>
    /// A distance range that the gun can aim accurately is 100
    /// </summary>
    public float range = 100f;

    //public float fireRate = 15f;

    /// <summary>
    /// The impact of the gun's bullet does 50
    /// </summary>
    public float impactForce = 50f;

    /// <summary>
    /// To connect the main camera into the first person
    /// </summary>
    public Camera fpsCam;

    /// <summary>
    /// To connect 
    /// </summary>
    public ParticleSystem muzzleFlash;
    // public GameObject impactEffect;

    private float nextTimeToFire = 0f;

    [SerializeField] private AudioClip gunAudio;

    /// <summary>
    /// AudioSource for the sound of fire golem dying
    /// </summary>
    //public AudioSource golem_hit;

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
        AudioSource.PlayClipAtPoint(gunAudio, transform.position, 1f);
        RaycastHit hit;
        
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            fireGolem_AI FireGolem_AI = hit.transform.GetComponent<fireGolem_AI>();

            //golem_hit.enabled = true;

            if (FireGolem_AI != null)
            {
                FireGolem_AI.TakeDamage(damage);
            }

            if(hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }

            // Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));

        }
    }

}
