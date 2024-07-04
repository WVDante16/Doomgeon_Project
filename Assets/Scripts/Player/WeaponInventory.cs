using UnityEngine;

public class WeaponInventory : MonoBehaviour
{
    //Variables publicas
    public bool gun = false;
    public bool hook = false;

    [Header("Weapons")]
    public GameObject Gun;
    public GameObject Hook;

    //Variables privadas
    private bool equippedGun = false;
    private bool equippedHook = false;

    private void Update()
    {
        //Detectar los inputs de cambio de armas 1 y 2
        if (Input.GetKeyDown(KeyCode.Alpha1) && gun == true)
        {
            if (!equippedGun)
            {
                EquipGun();
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && hook == true)
        {
            if (!equippedHook)
            {
                EquipHook();
            }
        }
    }

    //Funcion para equipar la pistola
    private void EquipGun()
    {
        //Comprobar si esta equipado el gancho
        if (equippedHook)
        {
            equippedHook = false;
            Hook.gameObject.SetActive(false);
        }

        //Activar pistola
        equippedGun = true;
        Gun.gameObject.SetActive(true);
    }

    //Funcion para equipar el gancho
    private void EquipHook()
    {
        //Comprobar si esta equipada la pistola
        if (equippedGun)
        {
            equippedGun = false;
            Gun.gameObject.SetActive(false);
        }

        //Activar el Hook
        equippedHook = true;
        Hook.gameObject.SetActive(true);
    }
}
