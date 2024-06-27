using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class waterBoy_trigger : Interactable
{
    [SerializeField] GameObject dialogueBox;
    [SerializeField] GameObject speech;

    private int index;

    // Start is called before the first frame update
    void Start()
    {
        dialogueBox.SetActive(false);
        speech.SetActive(true);
        GameManager.Instance.textComponent.text = string.Empty;
    }

    public override void Dialogue()
    {
        base.Dialogue();
    }

}
