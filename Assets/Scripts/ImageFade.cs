using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageFade : MonoBehaviour
{
    public CanvasGroup screen;
    public Button menuButton;
    public float fadeDuration = 1f;

    float timer;

    public void StartImageFade() {
        timer += Time.deltaTime;
        screen.alpha = timer/fadeDuration;

        if (timer > fadeDuration) {
            menuButton.gameObject.SetActive(true);
        }
    }
}
