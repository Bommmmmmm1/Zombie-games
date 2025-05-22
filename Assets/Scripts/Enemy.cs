using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private int damage = 25;
    [SerializeField]
    private float speed = 1.5f;

    [SerializeField]
    private EnemyData data;

    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        SetEnemyValues();
    }

    // Update is called once per frame
    void Update()
    {
        Swarm();
    }

    private void SetEnemyValues()
    {
        GetComponent<Health>().SetHealth(data.hp, data.hp);
        damage = data.damage;
        speed = data.speed;
    }

    private void Swarm()   // Untuk MoveTowards
    {
        if (player != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Bullet")) 
        {
            Debug.Log("Enemy hit by bullet");
            this.GetComponent<Health>().Damage(50);
        }

        if (collider.CompareTag("Player"))
        {
            Debug.Log("Enemy hit the player!");

            // Akses komponen Health dari player
            Health playerHealth = collider.GetComponent<Health>();
            if (playerHealth != null)
            {
                playerHealth.Damage(damage);
            }
        }
    }

    private float damageCooldown = 1.0f; // 1 detik antar damage
    private float lastDamageTime = -999f;

private void OnTriggerStay2D(Collider2D collider)
{
    if (collider.CompareTag("Player"))
    {
        if (Time.time - lastDamageTime >= damageCooldown)
        {
            Health playerHealth = collider.GetComponent<Health>();
            if (playerHealth != null)
            {
                playerHealth.Damage(damage);
                lastDamageTime = Time.time;
                Debug.Log("Player took damage from OnTriggerStay2D!");
            }
        }
    }
}




}
