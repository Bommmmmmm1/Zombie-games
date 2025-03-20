using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed =5f;
    public Camera maincamera
    SpriteRenderer sr;
    Vector3 MoveDir;
    Rigidbody2D rb;
    
    void Start()
    {
        sr = GetComponent<SpriteRenderer();
        rb = GetComponent<Rigidbody2D();
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector3(MoveDir.x * speed, MoveDir.y * speed, 0);
    }

    void update()
    {
        float moveX = Input.GetAxis("Horizontal") * speed * Time.deltaTime; 
        float moveY = Input.GetAxis ("Vertical") * speed * Time.deltaTime; 
        MoveDir = new Vector3(moveX, moveY, 0).normalized; 

        if (mainCamera != null) 
        {
            mainCamera.transform.position = new Vector3(transform.position.x, transform.position.y, transform.z - 5f); 
         }
            float playerX = transform.position.x; 
            Vector2 mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
        if (mousePos.x < playerX) 
        {
            sr.flipx = true; 
        }     
        else 
        {
            sr.flipX = false; 
        }
        //moving 
        if (MoveDir.x != 0 || MoveDir.y != 0) 
        {
        am.SetBool ("Move", true); 
        }
        else 
        {
        am.SetBool ("Move", false); 
        }
 
    }
}