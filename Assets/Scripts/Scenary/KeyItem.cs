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
            //Añadir la key al inventario y desactivarla
            keyItemsInventory.AddItem(this.gameObject);
            gameObject.SetActive(false);
        }
    }
}
