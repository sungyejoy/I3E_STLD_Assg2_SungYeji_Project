using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class endTrigger : MonoBehaviour
{
    Stopwatch stopwatch;

    [SerializeField] GameObject endUI;

    // Start is called before the first frame update
    void Start()
    {
        endUI.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            endUI.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
