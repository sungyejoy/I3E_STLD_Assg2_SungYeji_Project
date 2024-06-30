using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bounceBall : PlayerHealth
{
    public Vector3 startForce;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        rigidbody.AddForce(startForce, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            TakeDamage(15);
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
