using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        //Comprobar si el objeto impactado es un enemigo
        if (collision.gameObject.CompareTag("Enemy"))
        {
            print("Hit " + collision.gameObject.name);
            Destroy(gameObject);
        }

        Destroy(gameObject);
    }
}
