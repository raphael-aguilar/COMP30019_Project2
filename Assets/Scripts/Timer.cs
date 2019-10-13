using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public static Timer Instance;
    public TextMeshProUGUI timeDisplay;

    public float levelTime = 120f;

    private float remainingTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        remainingTime = (levelTime - Time.timeSinceLevelLoad);
        if (remainingTime >= 0) {
            timeDisplay.text = remainingTime.ToString("F0");
        }
        else {
            gameObject.GetComponent<ImageFade>().StartImageFade();
        }
        
    }
}
