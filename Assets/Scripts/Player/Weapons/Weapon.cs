using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    //Variables publicas
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float bulletVelocity = 30f;
    public float bulletPrefabLifeTime = 3f;

    private void Update()
    {
        //Input de disparo, click izquierdo del raton
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            FireWeapon();
        }
    }

    //Funcion de disparo
    private void FireWeapon()
    {
        //Instanciacion de la bala
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, Quaternion.identity);

        //Añadir fuerza a la bala
        bullet.GetComponent<Rigidbody>().AddForce(bulletSpawn.forward.normalized * bulletVelocity, ForceMode.Impulse);

        //Destruir la bala despues de cierto tiempo
        StartCoroutine(DestroyBulletAfterTime(bullet, bulletPrefabLifeTime));
    }

    //Corrutina para destruir la bala despues de cierto tiempo
    private IEnumerator DestroyBulletAfterTime(GameObject bullet, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(bullet);
    }
}
