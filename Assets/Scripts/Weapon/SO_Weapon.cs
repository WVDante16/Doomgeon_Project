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
    [SerializeField] float fireRange;
    [SerializeField] float fireRate;
    [SerializeField] int magazineCapacity; //Tama�o del cargador del arma
    [SerializeField] int magazine;
    [SerializeField] int ammoTotal; //Numero total de municion
    [SerializeField] AmmoClass ammoType;

    #endregion

    public string Name { get { return name; } }
    public string Description { get { return description; } }

    public float Damage { get { return damage; } }
    public float FireRange { get { return fireRange; } }
    public float FireRate { get { return fireRate; } }
    public int MagazineCapacity { get { return magazineCapacity; } }
    public int Magazine { get { return magazine; } set { magazine = value; } }
    public int AmmoTotal { get { return ammoTotal; } set { ammoTotal = value; } }
    public AmmoClass AmmoType { get { return ammoType; } }

}

public enum AmmoClass
{
    shotgun, pistol, submachine, sniper, heavy
}