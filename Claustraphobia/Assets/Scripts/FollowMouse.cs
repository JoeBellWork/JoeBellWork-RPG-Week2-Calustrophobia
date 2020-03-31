using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    private Rigidbody2D body;
    public Camera cam;
    public float speed;
    private Vector3 posZ;

    

    private void Start()
    {
        posZ = transform.position;
        body = GetComponent<Rigidbody2D>();        
    }






    void Update()
    {
        face();     
    }


    void face()
    {
        //player follow mouse
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        


        //face mouse
        Vector2 direction = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);
        transform.up = direction;
        // end


        //camera follow player
        Vector3 camPos = new Vector3(this.transform.position.x, this.transform.position.y, -15f);
        cam.transform.position = Vector3.Lerp(cam.transform.position, camPos, (speed - 1) * Time.deltaTime);



        //raycast to hit walls
        RaycastHit2D hit = Physics2D.Raycast(this.gameObject.transform.position,transform.up);
        if(hit.collider != null)
        {
            

            if (Vector2.Distance(mousePos, transform.position) > 1.25f)
            {

                if (hit.collider.gameObject.tag != "Wall")
                {
                    // move player                     
                    transform.position = Vector2.MoveTowards(transform.position, mousePos, speed * Time.deltaTime);
                }
                else if (hit.distance >= 1f && hit.collider.gameObject.tag == "Wall")
                {
                    // move player
                    transform.position = Vector2.MoveTowards(transform.position, mousePos, speed * Time.deltaTime);
                }
                else if (hit.distance >= 0.5f && hit.collider.gameObject.tag == "Cryo")
                {
                    // move player
                    transform.position = Vector2.MoveTowards(transform.position, mousePos, speed * Time.deltaTime);
                }
            }

        }       
    }
}
