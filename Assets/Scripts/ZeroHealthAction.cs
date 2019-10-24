using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZeroHealthAction : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<Image>().fillAmount <= 0){
            gameObject.GetComponent<ImageFade>().StartImageFade();
        }
    }
}
