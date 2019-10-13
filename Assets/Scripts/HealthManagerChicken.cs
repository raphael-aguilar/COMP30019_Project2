using UnityEngine;
using System.Collections;

public class HealthManagerChicken : MonoBehaviour
{

    public GameObject createOnDestroy;
    public int startingHealth = 100;
    public int numberOfChicks = 5;
    public GameObject chickPrefab;
    public GameObject player;
    private int currentHealth;

    // Use this for initialization
    void Start()
    {
        this.ResetHealthToStarting();
    }

    // Reset health to original starting health
    public void ResetHealthToStarting()
    {
        currentHealth = startingHealth;
    }

    // Reduce the health of the object by a certain amount
    // If health lte zero, destroy the object
    public void ApplyDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Destroy(this.gameObject);
            GameObject obj = Instantiate(this.createOnDestroy);
            obj.transform.position = this.transform.position;
            for (int i = 0; i <= numberOfChicks; i++)
            {
                GameObject chick = Instantiate<GameObject>(chickPrefab);
                chick.transform.position = this.transform.position;

                Vector3 chickVelocity = (player.transform.position - chick.transform.position).normalized;
                chickVelocity.x += Random.Range(-0.4f, 0.4f);
                chickVelocity.z += Random.Range(-0.4f, 0.4f);
                //Facing direciton isn't working atm, maybe please ask
                //chick.transform.rotation = Quaternion.LookRotation(chickVelocity);
                //chick.transform.LookAt(chickVelocity);
                //Debug.Log("chick velocity: " + chickVelocity);

                chick.GetComponent<ProjectileController>().velocity = chickVelocity;

            }
        }
    }

    // Get the current health of the object
    public int GetHealth()
    {
        return this.currentHealth;
    }
}
