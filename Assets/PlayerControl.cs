using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float speed = 5f; // Kecepatan gerakan pemain
    public GameObject bulletPrefab; // Prefab peluru
    public Transform shootingPoint; // Titik dari mana peluru ditembakkan
    public float fireRate = 0.1f; // Kecepatan tembakan

    private float nextFireTime = 0f; // Waktu berikutnya bisa menembak

    // Update is called once per frame
    void Update()
    {
        // Menggerakkan pemain
        MovePlayer();

        // Menembak jika tombol mouse ditekan
        if (Input.GetMouseButton(0))
        {
            if (Time.time >= nextFireTime)
            {
                Debug.Log("Menembak peluru!"); // Log untuk debugging
                Shoot();
                nextFireTime = Time.time + fireRate; // Atur waktu berikutnya bisa menembak
            }
        }
        else
        {
            // Log saat tidak menembak untuk melihat apakah input mouse terdeteksi
            Debug.Log("Tidak menembak");
        }
    }

    void MovePlayer()
    {
        float moveX = Input.GetAxis ("Horizontal") * speed * Time.deltaTime; 
        float moveY = Input.GetAxis ("Vertical") * speed * Time.deltaTime; 
        transform.Translate (new Vector3 (moveX, moveY, 0));
    }

    void Shoot()
    {
        // Membuat peluru baru
        GameObject bullet = Instantiate(bulletPrefab, shootingPoint.position, shootingPoint.rotation);

        // Menambahkan kecepatan ke peluru
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = shootingPoint.up * 10f; // Sesuaikan kecepatan peluru
    }
}
