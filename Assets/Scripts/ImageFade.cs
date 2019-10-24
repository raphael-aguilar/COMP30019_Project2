using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageFade : MonoBehaviour
{
    public CanvasGroup screen;
    public CanvasGroup otherScreen1;
    public CanvasGroup otherScreen2;
    public Button menuButton;
    public float fadeDuration = 1f;

    float timer;

    public void StartImageFade() {
        if (otherScreen1.alpha == 0 && otherScreen2.alpha == 0){
            timer += Time.deltaTime;
            screen.alpha = timer/fadeDuration;
    
            if (timer > fadeDuration) {
                menuButton.gameObject.SetActive(true);
            }
        }
    }
}
