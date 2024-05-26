using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyItem : MonoBehaviour
{
    //Variables Privada
    private KeyItems_Inventory keyItemsInventory;

    private void Start()
    {
        keyItemsInventory = FindObjectOfType<KeyItems_Inventory>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //Comprobar que es el jugador
        if (other.tag == "Player")
        {
            Debug.Log("PlayerContact");

            //Añadir la key al inventario y destruirla
            keyItemsInventory.AddItem(this.gameObject);
            //Destroy(this);
        }
    }
}
