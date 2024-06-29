using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpIncrease : Interactable
{

    float increaseJumpHeight = 6.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    public override void Collectible(player player)
    {
        player.GetComponent<FirstPersonController>().JumpHeight += increaseJumpHeight;
        base.Collectible(player);

    }

    // Update is called once per frame
    void Update()
    {

    }
}
