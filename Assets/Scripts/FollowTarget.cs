using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;

    // Default translation for the turtle   
    private Vector3 skew = new Vector3(0, 10, -2);

    private float min_y = 5;
    private float max_y = 20;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        // If target is null there is nothing to follow
        if (!target) {
            return;
        }

        // Use this to change the view for recording clips
        
        skew = skew + new Vector3(0, Input.mouseScrollDelta.y, 0);

        if (skew.y > max_y) {
            skew = new Vector3(skew.x, max_y, skew.z);
        }

        if (skew.y < min_y) {
            skew = new Vector3(skew.x, min_y, skew.z);
        }

        
        this.transform.position = target.position + skew;
        this.transform.LookAt(target);
    }
}