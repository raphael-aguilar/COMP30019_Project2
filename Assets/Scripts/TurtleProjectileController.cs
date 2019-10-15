using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TurtleProjectileController : MonoBehaviour
{

    public Vector3 velocity;

    public int damageAmount = 25;
    public string tagToDamage;
    public string tagToScenery;

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(velocity * Time.deltaTime);
    }

    // Handle collisions
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == tagToDamage)
        {
            // Damage object with relevant tag
            HealthManagerChicken healthManager = col.gameObject.GetComponent<HealthManagerChicken>();
            healthManager.ApplyDamage(damageAmount);

            // Destroy self
            Destroy(this.gameObject);
        }
        if (col.gameObject.tag == tagToScenery){
            Destroy(this.gameObject);
        }
    }
}
