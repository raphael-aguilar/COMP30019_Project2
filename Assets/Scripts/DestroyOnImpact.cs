using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DestroyOnImpact : MonoBehaviour
{    public string tagToGetDamage;
    public GameObject createOnDestroy;
    // Update is called once per frame
    void Update()
    {
    }

    // Handle collisions
    void OnTriggerEnter(Collider col)
    {
        Debug.Log(col.gameObject.tag);
        if (col.gameObject.tag == tagToGetDamage)
        {            // Destroy self
            Destroy(this.gameObject);
            GameObject obj = Instantiate(this.createOnDestroy);
            obj.transform.position = this.transform.position;
        } 
    }
}
