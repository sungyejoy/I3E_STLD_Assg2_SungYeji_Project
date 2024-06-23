using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class waterBoy_trigger : MonoBehaviour
{
    [SerializeField] GameObject dialogueBox;
    [SerializeField] GameObject speech;
    public TextMeshProUGUI textComponent;
    [SerializeField] private AudioClip talking;
    public string[] lines;
    public float textSpeed;

    private int index;

    // Start is called before the first frame update
    void Start()
    {
        dialogueBox.SetActive(false);
        speech.SetActive(true);
        textComponent.text = string.Empty;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            speech.SetActive(false);
            dialogueBox.SetActive(true);
            textComponent.text = string.Empty;
            StartDialogue();
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
            }

            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }

    public void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
        AudioSource.PlayClipAtPoint(talking, transform.position, 1f);
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
            Debug.Log(lines.Length);
            Debug.Log(index);
        }

        else
        {
            Debug.Log("hi");
            dialogueBox.SetActive(false);
            textComponent.text = null;
            AudioSource.Destroy(talking);
            gameObject.SetActive(false);
        }
    }
}
