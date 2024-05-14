using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemy/New Enemy")]
public class SO_Enemy : ScriptableObject
{

    /*
     * COSAS POR HACER:
     * 
     * Los enemigos al morir deber�an soltar un tipo de munici�n o soltar X cantidad de munici�n general.
     * 
     */

    #region Data

    [SerializeField] new string name;
    [TextArea]
    [SerializeField] string description;

    #endregion

    #region Stats

    [SerializeField] float health;
    [SerializeField] float damage;

    #endregion

    public string Name { get { return name; } }
    public string Description { get { return description; } }
    
    public float Health { get { return health; } set { health = value; } }
    public float Damage { get { return damage; } set { damage = value; } }

}
