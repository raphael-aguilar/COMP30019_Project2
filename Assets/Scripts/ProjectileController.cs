using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ProjectileController : MonoBehaviour
{

    public Vector3 velocity;

    public int damageAmount = 25;
    public string tagToDamage;
    public string tagToScenery;
    public int speed = 1;
    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(velocity * Time.deltaTime * speed);
    }

    // Handle collisions
    void OnTriggerEnter(Collider col)
    {
        Debug.Log(col.gameObject.tag);
        if (col.gameObject.tag == tagToDamage)
        {
            // Damage object with relevant tag
            HealthManager healthManager = col.gameObject.GetComponent<HealthManager>();
            healthManager.ApplyDamage(damageAmount);

            // Destroy self
            Destroy(this.gameObject);
        } 
        if (col.gameObject.tag == tagToScenery){
            Destroy(this.gameObject);
        }
    }
}
