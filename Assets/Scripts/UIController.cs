using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public static UIController instance;

    public Image heart1, heart2, heart3;

    public Sprite fullHeart, emptyHeart, halfHeart;
    public Text clockText;
    public Image fadeScreen;
    public float fadeSpeed;
    private bool shouldFadeToBlack, shouldFadeFromBlack;
    public GameObject levelCompleteText;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        UpdateClockCount();
        FadeFromBlack();
    }

    // Update is called once per frame
    void Update()
    {
        if (shouldFadeToBlack)
        {
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, 1f, fadeSpeed * Time.deltaTime));

            if (fadeScreen.color.a == 1f)
            {
                shouldFadeToBlack = false;
            }
        }

        if (shouldFadeFromBlack)
        {
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, 0f, fadeSpeed * Time.deltaTime));

            if (fadeScreen.color.a == 0f)
            {
                shouldFadeFromBlack = false;
            }
        }
    }

    public void UpdateHealthDisplay()
    {
        switch (PlayerHealthController.instance.currentHealth)
        {
            case 6:
                heart1.sprite = fullHeart;
                heart2.sprite = fullHeart;
                heart3.sprite = fullHeart;
                break;
            case 5:
                heart1.sprite = fullHeart;
                heart2.sprite = fullHeart;
                heart3.sprite = halfHeart;
                break;
            case 4:
                heart1.sprite = fullHeart;
                heart2.sprite = fullHeart;
                heart3.sprite = emptyHeart;
                break;
            case 3:
                heart1.sprite = fullHeart;
                heart2.sprite = halfHeart;
                heart3.sprite = emptyHeart;
                break;
            case 2:
                heart1.sprite = fullHeart;
                heart2.sprite = emptyHeart;
                heart3.sprite = emptyHeart;
                break;
            case 1:
                heart1.sprite = halfHeart;
                heart2.sprite = emptyHeart;
                heart3.sprite = emptyHeart;
                break;
            case 0:
                heart1.sprite = emptyHeart;
                heart2.sprite = emptyHeart;
                heart3.sprite = emptyHeart;
                break;
        }
    }

    public void UpdateClockCount()
    {
        clockText.text = LevelManager.instance.clocksCollected.ToString();
    }

    public void FadeToBlack()
    {
        shouldFadeToBlack = true;
        shouldFadeFromBlack = false;
    }

    public void FadeFromBlack()
    {
        shouldFadeToBlack = false;
        shouldFadeFromBlack = true;
    }
}
