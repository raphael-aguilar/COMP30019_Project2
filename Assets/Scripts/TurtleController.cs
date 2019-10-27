using UnityEngine;
using System.Collections;

public class TurtleController : MonoBehaviour
{
    public float fasterspeed = 5.0f;
    public float speed = 3.0f; // Default speed sensitivity
    public Rigidbody rb;
    // Use this for initializationz

    public string getDamaged;


    public GameObject turtle_model;

    private bool isDamaged = false;
    private bool isOn = false;

    private float time = 0;

    private float initialYPos;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        initialYPos = transform.position.y;

    }

    // Update is called once per frame
    void Update()
    {
        ControlTurtle();

        // transform.position = new Vector3(transform.position.x, initialYPos, transform.position.z);
        rb.velocity = Vector3.zero;

        if (isDamaged) {
            time += Time.deltaTime;

            if (isOn) {
                turtle_model.GetComponent<Renderer>().material.SetFloat("_RimPower", 0);
            } else {
                turtle_model.GetComponent<Renderer>().material.SetFloat("_RimPower", 8);
            }
            isOn = !isOn;

            if (time > 0.5f) {
                time = 0;
                isDamaged = false;
                turtle_model.GetComponent<Renderer>().material.SetFloat("_RimPower", 8);
            }
        }



    }

    void LateUpdate() {
        transform.position = new Vector3(transform.position.x, initialYPos, transform.position.z);
        // ControlTurtle();
    }
    void ControlTurtle()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        float currentspeed = Input.GetButton("Run")?fasterspeed:speed;

        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);
        // transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15F);

        if (movement != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement.normalized), 0.2f);
        }
        transform.Translate(movement * currentspeed * Time.deltaTime, Space.World);


        if (Input.anyKey == true)
        {
            gameObject.GetComponent<Animator>().Play("STurtle_Walk_Anim");
        }
        else
        {
            gameObject.GetComponent<Animator>().Play("STurtle_Idle_Anim");
        }

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Mouse0))
        {
            // DisableRagdoll();
        }
        else
        {
            EnableRagdoll();
        }
        if (currentspeed == fasterspeed){
            Animator animator = gameObject.GetComponent<Animator>();
            animator.speed = fasterspeed;
        } else {
            Animator animator = gameObject.GetComponent<Animator>();
            animator.speed = 1f;
        }

    }
    // Let the rigidbody take control and de"Rim Power"tect collisions, .
    void EnableRagdoll()
    {
        rb.isKinematic = false;
        rb.detectCollisions = true;
    }

    // Let animation control the rigidbody and ignore collisions.
    void DisableRagdoll()
    {
        rb.isKinematic = true;
        rb.detectCollisions = false;
    }

    void OnTriggerEnter(Collider col) {
        
        if (col.gameObject.tag == getDamaged) {
            isDamaged = true;
            time = 0;
        }
    }

}
