using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public GameObject bulletPrefab; // Prefab peluru
    public Transform shootingPoint; // Titik dari mana peluru ditembakkan
    public float fireRate = 0.1f; // Kecepatan tembakan
    private float nextFireTime = 0f; // Waktu berikutnya bisa menembak

    // Update is called once per frame
    void Update()
    {
        // Mengarahkan pemain ke posisi mouse
        AimPlayer();

        // Menembak jika tombol mouse ditekan dan waktu sekarang lebih besar dari nextFireTime
        if (Input.GetMouseButton(0) && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate; // Set next fire time based on fire rate
        }
    }

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
        rb.velocity = shootingPoint.up * 10f; // Sesuaikan kecepatan peluru
    }
}
