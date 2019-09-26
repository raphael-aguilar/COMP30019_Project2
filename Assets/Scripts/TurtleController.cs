using UnityEngine;
using System.Collections;

public class TurtleController : MonoBehaviour
{

    public float speed = 1.0f; // Default speed sensitivity

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        ControlTurtle();
    }
    void ControlTurtle()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);
        // transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15F);

        if (movement != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement.normalized), 0.2f);
        }
        transform.Translate(movement * speed * Time.deltaTime, Space.World);


        if (Input.anyKey == true)
        {
            gameObject.GetComponent<Animator>().Play("STurtle_Walk_Anim");
        }
        else
        {
            gameObject.GetComponent<Animator>().Play("STurtle_Idle_Anim");
        }
    }
        void OnCollisionEnter(Collision collision)
    {
        
    }

}
