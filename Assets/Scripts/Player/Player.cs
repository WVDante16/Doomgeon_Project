using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

// Definici�n de la clase Player que hereda de MonoBehaviour
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

    private float interactionRange = 2.5f; // Rango de interacci�n del jugador
    private bool isInteracting = false; // Variable para rastrear si el jugador est� interactuando con un objeto

    // Start se llama antes de la primera actualizaci�n del frame
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
        PlayerRay();
    }

    // M�todo para que el jugador reciba da�o
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

        // Si la salud del jugador es menor o igual a cero, se llama al m�todo Die
        if (hp <= 0)
        {
            Die();
        }
    }

    // M�todo para curar al jugador
    public void Heal(int heal)
    {
        // Solo cura al jugador si su salud es menor o igual a la salud m�xima definida en el ScriptableObject
        if (hp <= so_player.Health)
        {
            hp += heal;
        }

        // Actualiza la interfaz de usuario con los nuevos valores de salud y armadura
        playerUI.UpdateHpAr(hp, armor);
    }

    // M�todo para aumentar la armadura del jugador
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

    // M�todo para manejar la muerte del jugador
    public void Die()
    {
        // Destruye el objeto del jugador
        Destroy(gameObject);
    }


    public void PlayerRay()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactionRange))
        {
            if (hit.collider.CompareTag("NPC") || hit.collider.CompareTag("Key") || hit.collider.CompareTag("DropWeapon"))
            {
                playerUI.textBox.text = $"Presiona [E] para interactuar";
                playerUI.textBoxBG.SetActive(true);
                isInteracting = true;  // El jugador est� interactuando con un objeto
            }
            else
            {
                isInteracting = false;  // El raycast no golpe� un objeto interactivo
            }
        }
        else
        {
            isInteracting = false;  // El raycast no golpe� nada
        }

        // Si el jugador no est� interactuando, desactivar textBoxBG
        if (!isInteracting)
        {
            playerUI.textBoxBG.SetActive(false);
        }
    }

}