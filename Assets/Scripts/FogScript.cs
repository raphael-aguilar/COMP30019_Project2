using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogScript : MonoBehaviour
{
    public Shader shader;
    // Start is called before the first frame update
    void Start()
    {
        Material material = new Material(shader);
        this.GetComponent<Renderer>().material = material;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
