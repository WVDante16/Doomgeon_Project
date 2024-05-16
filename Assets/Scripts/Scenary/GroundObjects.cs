using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GroundObjects : MonoBehaviour
{

    public Player player;

    [SerializeField] string keyName;
    
    [SerializeField] SO_Weapon dropWeapon;

    public string KeyName { get { return keyName; } } 

    public SO_Weapon DropWeapon { get { return dropWeapon; } }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {

            //En caso de que el jugador choque contra el objeto se agrega a su inventario
            if(gameObject.tag == "Key")
            {
                addKey(keyName);
            }
            else if(gameObject.tag == "DropWeapon") 
            {
                addDropWeapon(dropWeapon);
            }

        }

    }

    //Agrega la llave al inventario
    public void addKey(string keyName)
    {
        player.so_player.KeyInventory.Add(keyName);
        Destroy(gameObject) ;
    }

    //Agrega el arma al inventario
    public void addDropWeapon(SO_Weapon so_Weapon)
    {

        player.so_player.Weapons.Add(so_Weapon);
        Destroy(gameObject) ;

    }

}
