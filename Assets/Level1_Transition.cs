using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level1_Transition : MonoBehaviour
{
    public Animator transition;

    public float transitionTime = 1f;

    [SerializeField] GameObject interact_text;
    [SerializeField] GameObject level1_collider;

    // Start is called before the first frame update
    void Start()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            interact_text.SetActive(true);
            LoadNextLevel();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            interact_text.SetActive(false);
        }
    }

    public void LoadNextLevel()
    {
        StartCoroutine(
            LoadLevel(SceneManager.GetActiveScene().buildIndex + 1)
            );
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        // Play animation
        transition.SetTrigger("Start");

        /// <summary>
        /// Pauses the transition for x seconds
        /// </summary>
        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
        // Wait

        // Load scene
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
