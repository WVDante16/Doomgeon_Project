using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyItems_Inventory : MonoBehaviour
{
    //Variables publicas
    public List<GameObject> keyItemsInventory = new List<GameObject>();

    //Funcion para añadir GameObjects al arreglo
    public void AddItem(GameObject item)
    {
        keyItemsInventory.Add(item);
    }
}
