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
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        followCursor();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            float distancePlane = Camera.main.transform.position.y;

            Vector3 screenPosWithDistance = (Vector3)Input.mousePosition + (Vector3.forward * distancePlane);//*distancePlane);
            Vector3 positionWorld = Camera.main.ScreenToWorldPoint(screenPosWithDistance);

            Vector3 direction = (positionWorld - this.transform.position);
            //Debug.Log("direction: " + direction);
            //Debug.Log("mouse_position " + Input.mousePosition);
            GameObject projectile = Instantiate<GameObject>(projectilePrefab);
            projectile.transform.position = this.gameObject.transform.position;
            projectile.GetComponent<ProjectileController>().velocity = direction * 10;
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

}
