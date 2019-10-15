using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    // Start is called before the first frame update


    public GameObject player;
    
    private float y_dist = 10;
    private float x_dist = 0;
    private float z_dist = 2;

    private float x_rot = 80;
    private float y_rot = 0;
    private float z_rot = 0;

    

    void Start()
    {
        // Vector3 rotation = new Vector3(x_rot, y_rot, z_rot);

        this.transform.rotation = Quaternion.Euler(x_rot, y_rot, z_rot);
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 position = new Vector3(player.transform.position.x - x_dist, player.transform.position.y + y_dist, player.transform.position.z - z_dist);
        this.transform.position = position;
    }
}