using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

// Definici�n de la clase UIDisplay que hereda de MonoBehaviour
public class UIDisplay : MonoBehaviour
{
    // Referencia al objeto Player
    public Player player;

    // Referencias a los elementos de texto de la interfaz de usuario (UI)
    public TMP_Text ammoText;  // Para mostrar la munici�n
    public TMP_Text hpText;    // Para mostrar la salud
    public TMP_Text armorText; // Para mostrar la armadura
    public TMP_Text textBox;   // Para mostrar mensajes en una caja de texto

    // Referencia al fondo de la caja de texto
    public GameObject textBoxBG;

    // Start se llama antes de la primera actualizaci�n del frame
    void Start()
    {
        // Actualiza el texto de munici�n con los valores iniciales del arma en mano del jugador
        UpdateAmmo(player.WeaponInHand.Magazine, player.WeaponInHand.AmmoTotal);
    }

    // Update se llama una vez por frame
    void Update()
    {
        // Actualmente vac�o, pero aqu� se pueden agregar actualizaciones por frame si es necesario
    }

    // M�todo para actualizar el texto de la munici�n
    public void UpdateAmmo(int magazine, int ammoTotal)
    {
        // Formatea y actualiza el texto de la munici�n
        ammoText.text = $"{magazine}/{ammoTotal}";
    }

    // M�todo para actualizar el texto de la salud y armadura
    public void UpdateHpAr(int hp, int armor)
    {
        // Convierte los valores de salud y armadura a texto y los actualiza en la UI
        hpText.text = hp.ToString();
        armorText.text = armor.ToString();
    }
}