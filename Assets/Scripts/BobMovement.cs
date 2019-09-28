using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobMovement : MonoBehaviour
{
    public float speed = 0.5f;
    public float height = 0.5f;
    public float delay;

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.localPosition;
        float newY = Mathf.Sin((Time.time * speed)+delay);
        transform.localPosition = new Vector3(pos.x, newY, pos.z) * height;
        
    }
}
