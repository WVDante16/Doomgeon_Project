using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon/New Weapon")]
public class SO_Weapon : ScriptableObject
{

    #region Data

    [SerializeField] new string name;
    [TextArea]
    [SerializeField] string description;

    #endregion

    #region Stats

    [SerializeField] float damage;
    [SerializeField] int magazineCapacity; //Tamaño del cargador del arma
    [SerializeField] int ammoTotal; //Numero total de municion
    [SerializeField] AmmoClass ammoType;

    #endregion

    public string Name { get { return name; } }
    public string Description { get { return description; } }

    public float Damage { get { return damage; } }
    public int MagazineCapacity { get {  return magazineCapacity; } set { magazineCapacity = value; } }
    public int AmmoTotal { get { return ammoTotal; }  set { ammoTotal = value; } }
    public AmmoClass AmmoType { get { return ammoType; } }

}

public enum AmmoClass
{
    shotgun, pistol, submachine, sniper, heavy
}
