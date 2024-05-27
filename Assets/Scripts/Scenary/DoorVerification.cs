using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorVerification : MonoBehaviour
{
    //Variables privadas 
    public Door door;

    private void OnTriggerEnter(Collider other)
    {
        //Comprobar que el que entra es el player
        if (other.tag == "Player")
        {
            //Activar booleano al entrar al box collider
            door.inRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //Comprobar que el que entra es el player
        if (other.tag == "Player")
        {
            //Activar booleano al entrar al box collider
            door.inRange = false;
        }
    }
}
