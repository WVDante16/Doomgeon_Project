using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 3f; // Velocidad de movimiento del enemigo
    public int health = 100; // Salud del enemigo

    private Transform target; // Transform del jugador

    void Start()
    {
        // Encontrar el GameObject del jugador al inicio
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        // Mover el enemigo hacia el jugador
        transform.LookAt(target.position);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    // Función para recibir daño
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    // Función para cuando el enemigo muere
    void Die()
    {
        // Aquí puedes agregar cualquier efecto de muerte, como sonidos, partículas, etc.
        Destroy(gameObject);
    }
}
