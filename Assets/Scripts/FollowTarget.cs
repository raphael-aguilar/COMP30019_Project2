using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    // Start is called before the first frame update


    public GameObject player;
    
    public float height;
    private float x_dist = 0;
    private float z_dist = 5;

    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 position = new Vector3(player.transform.position.x - x_dist, height, player.transform.position.z - z_dist);
        this.transform.position = position;
    }
}
