using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickController : MonoBehaviour
{

    public int damageAmount = 25;
    public string tagToDamage;
    public string tagToScenery;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<Rigidbody>().velocity = transform.forward * 2.5f;


        // Makes sure the chick doesn't change height
        Vector3 newPos = this.GetComponent<Rigidbody>().position;
        newPos.y = 0;
        this.GetComponent<Rigidbody>().position = newPos;

        gameObject.GetComponent<Animator>().Play("Jump W Root");
    }
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
