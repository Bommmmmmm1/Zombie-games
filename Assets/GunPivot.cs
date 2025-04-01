using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPivot : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;
    public Camera m_camera;
    public Transform fire_point;
    public GameObject Bullet;
    public Transform gunholder;

    public float fireRate = 0.5f; // Time between shots
    private float nextFireTime = 0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        RotateGun();
        HandleMovement();
        Shoot();
    }

    void RotateGun()
    {
        Vector2 distanceVector = (Vector2)m_camera.ScreenToWorldPoint(Input.mousePosition) - (Vector2)gunholder.position;
        float angle = Mathf.Atan2(distanceVector.y, distanceVector.x) * Mathf.Rad2Deg;

        angle -= 90f; 
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

void Shoot()
{
    if (Input.GetMouseButton(0) && Time.time >= nextFireTime)
    {
        nextFireTime = Time.time + fireRate;

        Debug.Log("Shooting from: " + fire_point.position); // Log fire point position

        GameObject bullet = Instantiate(Bullet, fire_point.position, fire_point.rotation);
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
        bulletRb.linearVelocity = fire_point.up * 10f;

        Debug.Log("Bullet instantiated at: " + bullet.transform.position); // Log bullet position
    }
}


    private void FixedUpdate()
    {
        // Move the player
        rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
    }

    void HandleMovement()
    {
        movement.x = Input.GetAxisRaw("Horizontal"); // A/D or Left/Right
        movement.y = Input.GetAxisRaw("Vertical");   // W/S or Up/Down
    }
}
