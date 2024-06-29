/*
* Author: Sung Yeji
* Date: 28/06/2024
* Description: Script for Medicine Pill
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class medicine : Interactable
{
    [SerializeField] GameObject medicine_pill;
    [SerializeField] GameObject player;
    [SerializeField] private AudioClip bonus_sound;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    public override void Collectible(player player)
    {

        AudioSource.PlayClipAtPoint(bonus_sound, transform.position, 1f);

        if (GameManager.Instance.currentHealth <= 100)
        {
            GameManager.Instance.currentHealth += 30f;
        }

        // Turn off warning UI
        GameManager.Instance.warning_img.SetActive(false);

        base.Collectible(player);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
