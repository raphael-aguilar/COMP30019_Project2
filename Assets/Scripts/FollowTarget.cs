using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;

    // Default translation for the turtle   
    private Vector3 skew = new Vector3(0, 10, -2);

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        // Use this to change the view for recording clips
        // skew = new Vector3(2f, 3f, -2f);
        
        this.transform.position = target.position + skew;
        this.transform.LookAt(target);
    }
}