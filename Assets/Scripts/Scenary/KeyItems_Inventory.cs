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

    //Checar el inventario
    public bool InInventory(string itemName)
    {
        bool inList = false;
        
        //Foreach que recorre la lista de items para comprobar si esta en el inventario
        foreach (GameObject gameObject in keyItemsInventory)
        {
            if (gameObject.name == itemName)
            {
                inList = true;
            }
        }

        //Resultado final a regresar dependiendo el resultado
        if (inList)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
