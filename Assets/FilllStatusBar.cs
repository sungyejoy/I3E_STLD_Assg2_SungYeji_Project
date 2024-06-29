using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FilllStatusBar : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public Image fillImage;
    private Slider slider;

    private void Awake()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (slider.value <= slider.minValue)
        {
            fillImage.enabled = false;
        }

        if (slider.value > slider.minValue && !fillImage.enabled)
        {
            fillImage.enabled = true;
        }

        float fillValue = GameManager.Instance.currentHealth / GameManager.Instance.maxHealth;

        if (fillValue <= slider.maxValue / 3)
        {
            fillImage.color = Color.red;
            GameManager.Instance.hurt.SetActive(true);
        }

        else if(fillValue > slider.maxValue / 3)
        {
            fillImage.color = Color.green;
            GameManager.Instance.hurt.SetActive(false);
        }

        slider.value = fillValue;
    }
}
