using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinGame : MonoBehaviour
{
    public GameObject enemies;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (enemies.transform.childCount == 0) {
            gameObject.GetComponent<ImageFade>().StartImageFade();
        }
    }
}
