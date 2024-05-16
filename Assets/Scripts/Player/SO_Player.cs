using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [CreateAssetMenu] permite crear instancias de este ScriptableObject desde el men� de Unity
[CreateAssetMenu(fileName = "New Player", menuName = "Player/New Player")]
public class SO_Player : ScriptableObject
{
    // Regi�n para agrupar los datos b�sicos del jugador
    #region Data

    // Nombre del jugador
    [SerializeField] new string name;
    // N�mero de muertes del jugador
    [SerializeField] int deaths;
    //Inventario de las llaves que tiene el jugador
    [SerializeField] List<string> keyInventory;

    #endregion

    // Regi�n para agrupar las estad�sticas del jugador
    #region Stats

    // Salud del jugador
    [SerializeField] int health;
    // Armadura del jugador
    [SerializeField] int armor;
    // Lista de armas que el jugador posee
    [SerializeField] List<SO_Weapon> weapons;

    #endregion

    // Regi�n para agrupar los elementos de la interfaz de usuario relacionados con el jugador
    #region UI

    // Lista de sprites para la interfaz de usuario que representan diferentes estados de da�o del jugador
    [SerializeField] List<Sprite> damageUI;

    #endregion

    // Propiedad para acceder y modificar el nombre del jugador
    public string Name { get { return name; } set { name = value; } }
    // Propiedad para acceder y modificar el n�mero de muertes del jugador
    public int Deaths { get { return deaths; } set { deaths = value; } }
    //Propiedad para acceder y modificar el inventario de llaves
    public List<string> KeyInventory { get { return keyInventory; } set { keyInventory = value; } }

    // Propiedad para acceder y modificar la salud del jugador
    public int Health { get { return health; } set { health = value; } }
    // Propiedad para acceder y modificar la armadura del jugador
    public int Armor { get { return armor; } set { armor = value; } }
    // Propiedad para acceder y modificar la lista de armas del jugador
    public List<SO_Weapon> Weapons { get { return weapons; } set { weapons = value; } }

    // Propiedad solo de lectura para acceder a la lista de sprites de da�o de la interfaz de usuario
    public List<Sprite> DamageUI { get { return damageUI; } }
}