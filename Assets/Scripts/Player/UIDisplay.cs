using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using JetBrains.Annotations;
using System;

public class UIDisplay : MonoBehaviour
{

    public SO_Weapon weapon;

    public TMP_Text ammo;

    // Start is called before the first frame update
    void Start()
    {

        ShowAmmo();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowAmmo()
    {
        int ammoTotal = weapon.AmmoTotal;
        int magazine = weapon.MagazineCapacity;

        ammoTotal = ammoTotal - magazine;

        ammo.text = $"{magazine}/{ammoTotal}";
    } 

}
