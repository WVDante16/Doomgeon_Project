using UnityEngine;

public class HookActivator : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //Comprobar si es el jugador el que entro en el trigger y destruir la caja
        if (other.tag == "Player")
        {
            other.GetComponentInChildren<WeaponInventory>().hook = true;
            Destroy(gameObject);
        }
    }
}
