using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public SO_Enemy so_enemy;
    public HealthBar healthBar;
    public Player player;

    public float speed; // Velocidad de movimiento del enemigo
    public float hp; // Salud del enemigo
    public float hpMax; //Salud maxima del enemigo

    private Transform target; // Transform del jugador

    void Start()
    {

        hpMax = so_enemy.Health;
        hp = hpMax;

        // Encontrar el GameObject del jugador al inicio
        /*target = GameObject.FindGameObjectWithTag("Player").transform;*/
    }

    void Update()
    {
        // Mover el enemigo hacia el jugador
        /*transform.LookAt(target.position);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);*/
    }

    // Función para recibir daño
    public void TakeDamage(float damage)
    {
        hp -= damage;
        healthBar.UpdateHP(Convert.ToInt32(hp));
        if (hp <= 0)
        {
            Die();
        }
    }

    // Función para cuando el enemigo muere
    void Die()
    {
        // Aquí puedes agregar cualquier efecto de muerte, como sonidos, partículas, etc.
        Destroy(gameObject);

        for (int i = 1; i < (player.so_player.Weapons.Count) - 1; i++)
        {
            player.so_player.Weapons[i].AmmoTotal += player.so_player.Weapons[i].MagazineCapacity;
        }
    }
}