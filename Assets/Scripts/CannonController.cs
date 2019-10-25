using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//https://answers.unity.com/questions/10615/rotate-objectweapon-towards-mouse-cursor-2d.html
//https://answers.unity.com/questions/1322560/how-to-make-gun-shoot-and-aim-towards-the-mouse.html
public class CannonController : MonoBehaviour

{
    public GameObject projectilePrefab;
    public Vector3 mousePos;
    public Vector3 gunPos;
    public Transform target; //Assign to the object you want to rotate
    public float angle;

    private float bulletSpeed = 2.0f;

    // The time you are able to make between shots
    private float firerate = 0.5f;

    private float levelTimer;

    
    // Start is called before the first frame update
    void Start() { 
        levelTimer = firerate;
    }

    // Update is called once per frame
    void Update()
    {
        // cannon changes angle based on cursor position
        followCursor();

        levelTimer += Time.deltaTime;
        
        


        if (levelTimer > firerate) {
            // generates projectile when space is pressed
            makeProjectile();
        }

    }

    void followCursor()
    {
        mousePos = Input.mousePosition;
        gunPos = Camera.main.WorldToScreenPoint(transform.position);
        mousePos.x = mousePos.x - gunPos.x;
        mousePos.y = mousePos.y - gunPos.y;
        angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, -angle + 90, 0));

    }

    void makeProjectile()
    {


        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            // make a new cannnonball
            GameObject projectile = Instantiate<GameObject>(projectilePrefab);
            // make sure cannonball starts off in the cannon
            projectile.transform.position = this.gameObject.transform.position;
            Vector3 p = projectile.transform.position;
            p.y += 0.35f;
            projectile.transform.position = p;

            // calculate angle to shoot cannonball out
            angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
            projectile.transform.rotation = Quaternion.Euler(new Vector3(0, -angle + 90, 0));
            // shoot cannonball forward
            projectile.GetComponent<TurtleProjectileController>().velocity = bulletSpeed * Vector3.forward * 5;
            
            levelTimer = 0;
        }
    }

    

    

}
