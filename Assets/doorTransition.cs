using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class doorTransition : MonoBehaviour
{
    public Animator transition;

    public float transitionTime = 1f;

    public TextMeshProUGUI notificationText;
    [SerializeField] GameObject approval_img;

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<player>().gun_pickup == true)
        {
            approval_img.SetActive(true);
            notificationText.text = "Loading Level 1...";
            LoadNextLevel();
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
}
