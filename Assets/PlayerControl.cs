using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    //public float speed = 5f; // Kecepatan gerakan pemain
    public GameObject bulletPrefab; // Prefab peluru
    public Transform shootingPoint; // Titik dari mana peluru ditembakkan
    public float fireRate = 0.1f; // Kecepatan tembakan
    public float fireTimer = 0f; // Timer untuk membatasi tembakan
    
    private float nextFireTime = 0f; // Waktu berikutnya bisa menembak

    // Update is called once per frame
    void Update()
    {
        // Menggerakkan pemain
        //MovePlayer();

        // Mengarahkan pemain ke posisi mouse
        AimPlayer();

        // Menembak jika tombol mouse ditekan
        if (Input.GetMouseButton(0) && fireTimer <= 0f)
        {
            Shoot();
            fireTimer = fireRate; // Atur waktu cooldown tembakan
        }
        else
        {
            fireTimer -= Time.deltaTime; // Mengurangi timer seiring berjalannya waktu
        }
    }

    // void MovePlayer()
    // {
    //     float moveX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
    //     float moveY = Input.GetAxis("Vertical") * speed * Time.deltaTime;
    //     transform.Translate(new Vector3(moveX, moveY, 0));
    // }

    void AimPlayer()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float angle = Mathf.Atan2(mousePos.y - transform.position.y, mousePos.x - transform.position.x) * Mathf.Rad2Deg;
        transform.localRotation = Quaternion.Euler(0, 0, angle - 90f);
    }

    void Shoot()
    {
        // Membuat peluru baru
        GameObject bullet = Instantiate(bulletPrefab, shootingPoint.position, shootingPoint.rotation);

        // Menambahkan kecepatan ke peluru
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.linearVelocity = shootingPoint.up * 10f; // Sesuaikan kecepatan peluru
    }
}
