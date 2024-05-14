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
    private WeaponController[] weaponSlots = new WeaponController[5];

    void Start()
    {
        activeWeaponIndex = -1;

        foreach (GameObject startingWeaponPrefab in startingWeaponPrefabs)
        {
            AddWeapon(startingWeaponPrefab);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            SwitchWapon(0);
        }
    }

    private void SwitchWapon(int p_weaponIndex)
    {
        if(p_weaponIndex != activeWeaponIndex && p_weaponIndex >= 0)
        {
            weaponSlots[p_weaponIndex].gameObject.SetActive(true);
            activeWeaponIndex = p_weaponIndex;
        }
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
