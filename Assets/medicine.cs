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

    public override void Collectible()
    {
        AudioSource.PlayClipAtPoint(bonus_sound, transform.position, 1f);

        // Turn off warning UI
        GameManager.Instance.warning_img.SetActive(false);

        base.Collectible();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
