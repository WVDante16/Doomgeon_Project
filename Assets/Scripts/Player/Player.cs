using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Definición de la clase Player que hereda de MonoBehaviour
public class Player : MonoBehaviour
{
    // Referencia a un ScriptableObject de tipo SO_Player que contiene datos del jugador
    public SO_Player so_player;
    // Referencia a un objeto de interfaz de usuario para actualizar la pantalla del jugador
    public UIDisplay playerUI;

    // Variables privadas serializadas para la salud y armadura del jugador
    [SerializeField] int hp;
    [SerializeField] int armor;

    // Referencia al arma que el jugador tiene en la mano
    public SO_Weapon WeaponInHand;

    // Start se llama antes de la primera actualización del frame
    void Start()
    {
        // Inicializa la salud y la armadura del jugador con los valores del ScriptableObject
        hp = so_player.Health;
        armor = so_player.Armor;

        // Asigna el arma en la mano del jugador a la primera arma de la lista en el ScriptableObject
        WeaponInHand = so_player.Weapons[0];

        // Actualiza la interfaz de usuario con la salud y armadura iniciales
        playerUI.UpdateHpAr(hp, armor);
    }

    // Update se llama una vez por frame
    void Update()
    {
        // Actualmente vacío, pero aquí se pueden agregar actualizaciones por frame si es necesario
    }

    // Método para que el jugador reciba daño
    public void TakeDamage(int damage)
    {
        // Si el jugador tiene armadura, se reduce primero la armadura
        if (armor > 0)
        {
            armor -= damage;
        }
        // Si no tiene armadura, se reduce la salud
        else
        {
            hp -= damage;
        }

        // Actualiza la interfaz de usuario con los nuevos valores de salud y armadura
        playerUI.UpdateHpAr(hp, armor);

        // Si la salud del jugador es menor o igual a cero, se llama al método Die
        if (hp <= 0)
        {
            Die();
        }
    }

    // Método para curar al jugador
    public void Heal(int heal)
    {
        // Solo cura al jugador si su salud es menor o igual a la salud máxima definida en el ScriptableObject
        if (hp <= so_player.Health)
        {
            hp += heal;
        }

        // Actualiza la interfaz de usuario con los nuevos valores de salud y armadura
        playerUI.UpdateHpAr(hp, armor);
    }

    // Método para aumentar la armadura del jugador
    public void ArmorUp(int armorUp)
    {
        // Solo aumenta la armadura si es menor o igual a 100
        if (armor <= 100)
        {
            armor += armorUp;
        }

        // Actualiza la interfaz de usuario con los nuevos valores de salud y armadura
        playerUI.UpdateHpAr(hp, armor);
    }

    // Método para manejar la muerte del jugador
    public void Die()
    {
        // Destruye el objeto del jugador
        Destroy(gameObject);
    }
}