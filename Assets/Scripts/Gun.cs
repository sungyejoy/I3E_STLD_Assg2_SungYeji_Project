/*
* Author:  Sung Yeji
* Date: 15/06/2024
* Description: This script is for the gun in the firstpersonaio camera
*/

using UnityEngine;

/// <summary>
/// Represents a gun that can shoot projectiles.
/// </summary>
public class Gun : MonoBehaviour
{
    /// <summary>
    /// The amount of damage the gun does per shot.
    /// </summary>
    public float damage = 10;

    /// <summary>
    /// The maximum distance range the gun can accurately aim.
    /// </summary>
    public float range = 100f;

    /// <summary>
    /// The force applied to objects hit by the gun's projectile.
    /// </summary>
    public float impactForce = 50f;

    /// <summary>
    /// The main camera associated with the first-person perspective.
    /// </summary>
    public Camera fpsCam;

    /// <summary>
    /// The particle system used for muzzle flash when shooting.
    /// </summary>
    public ParticleSystem muzzleFlash;

    /// <summary>
    /// The audio clip played when the gun fires.
    /// </summary>
    [SerializeField] private AudioClip gunAudio;

    /// <summary>
    /// Performs a shooting action if the player has picked up the gun.
    /// </summary>
    public void Shoot()
    {
        if (GameManager.Instance.gun_pickup == true)
        {
            muzzleFlash.Play();
            AudioSource.PlayClipAtPoint(gunAudio, transform.position, 1f);
            RaycastHit hit;

            if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
            {
                Debug.Log(hit.transform.name);

                fireGolem_AI FireGolem_AI = hit.transform.GetComponent<fireGolem_AI>();

                if (FireGolem_AI != null)
                {
                    FireGolem_AI.TakeDamage(damage);
                }

                if (hit.rigidbody != null)
                {
                    hit.rigidbody.AddForce(-hit.normal * impactForce);
                }
            }
        }
    }
}