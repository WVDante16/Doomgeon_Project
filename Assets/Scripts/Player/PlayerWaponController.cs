using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponController : MonoBehaviour
{
    public List<GameObject> startingWeaponPrefabs = new List<GameObject>();
    public Transform weaponParentSocket;
    public Transform defaultWeaponPosition;
    public Transform aimingPosition;

    private int activeWeaponIndex;
    private WeaponController[] weaponSlots = new WeaponController[2];

    void Start()
    {
        activeWeaponIndex = -1;

        foreach (GameObject startingWeaponPrefab in startingWeaponPrefabs)
        {
            AddWeapon(startingWeaponPrefab);
        }
        SwitchWapon();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            SwitchWapon();
        }
    }

    private void SwitchWapon()
    {
        int tempIndex = (activeWeaponIndex + 1) % weaponSlots.Length;

        if (weaponSlots[tempIndex] == null) 
        {
            return;
        }

        foreach(WeaponController weapon in weaponSlots) 
        { 
            if (weapon != null) weapon.gameObject.SetActive(false);
            { 
                
            }
        }
            weaponSlots[tempIndex].gameObject.SetActive(true);
            activeWeaponIndex = tempIndex;
    }

    private void AddWeapon(GameObject weaponPrefab)
    {
        weaponParentSocket.position = defaultWeaponPosition.position;

        for (int i = 0; i < weaponSlots.Length; i++)
        {
            if (weaponSlots[i] == null)
            {
                WeaponController weaponClone = Instantiate(weaponPrefab, weaponParentSocket).GetComponent<WeaponController>(); 
                weaponClone.gameObject.SetActive(false);
                weaponSlots[i] = weaponClone;
                break;

                weaponSlots[i] = weaponClone;
                return;
            }
        }
    }
}
