using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//https://answers.unity.com/questions/969835/i-need-help-making-a-free-roaming-script-for-anima.html
public class ChickenController : MonoBehaviour
{
    public string tagBeenHit;
    public string tagToDamage;
    public Vector3 targetPos;
    public bool isMoving = false;
    public int damageAmount = 100;
    public float maxRange = 4f;
    public float waitTime = 0.0f;
    public float speed = 4f;
    public GameObject eggPrefab;
    public GameObject player;

    public float bulletSpeed = 2f;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //gameObject.GetComponent<Animator>().Play("Idle");
        if (isMoving == false)
        {
            FindNewTargetPos();
        }
        if (isMoving == true && this.transform.position != targetPos)
        {
            gameObject.GetComponent<Animator>().Play("Walk In Place");
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == tagBeenHit)
        {
            gameObject.GetComponent<Animator>().Play("Run In Place");
        }
        if (col.gameObject.tag == tagToDamage)
        {
            HealthManager healthManager = col.gameObject.GetComponent<HealthManager>();
            healthManager.ApplyDamage(damageAmount);

        }
    }

    private void FindNewTargetPos()
    {
        Vector3 pos = transform.position;
        targetPos = new Vector3();
        targetPos.x = Random.Range(pos.x - maxRange, pos.x + maxRange);
        targetPos.y = pos.y;
        targetPos.z = Random.Range(pos.z - maxRange, pos.z + maxRange);
        //this.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(targetPos.normalized), 0.2f);
        this.transform.LookAt(targetPos);
        StartCoroutine(Move());
    }

    IEnumerator Move()
    {
        isMoving = true;
        //Debug.Log("ienumerator called");

        for (float t = 0.0f; t <= 1.0f; t += Time.deltaTime * speed)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, t);
            yield return null;
        }
        //Debug.Log("loop finished");
        yield return new WaitForSeconds(waitTime);
        Fire();
        isMoving = false;
        yield return null;

    }
    void Fire()
    {
        GameObject egg = Instantiate<GameObject>(eggPrefab);
        egg.transform.position = this.transform.position;
        egg.GetComponent<ProjectileController>().velocity = bulletSpeed*(player.transform.position - egg.transform.position).normalized;

    }

}