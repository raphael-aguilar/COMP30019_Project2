using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        HealthManager healthManager = this.gameObject.GetComponent<HealthManager>();
    }
}