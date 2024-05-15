using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [Header("General")]
    public LayerMask _hittableLayers;
    public GameObject _bulletHolePrefab;

    [Header("Shoot Parameters")]
    public float _fireRange = 200f;
    public float _recoilForce = 0.2f;
    public float _recoilSpeed = 5f;
    public float _fireRate = 0.5f;

    private Transform _cameraPlayerTransform;
    private Vector3 _originalPosition;
    private float _nextFireTime; // Tiempo en el que se permitirá el próximo disparo

    private void Start()
    {
        _cameraPlayerTransform = GameObject.FindGameObjectWithTag("MainCamera").transform;
        _originalPosition = transform.localPosition;
        _nextFireTime = 0f; // Inicializar nextFireTime para permitir el primer disparo de inmediato
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time >= _nextFireTime)
        {
            HandleShoot();
            _nextFireTime = Time.time + _fireRate; // Establecer el próximo tiempo de disparo permitido
        }

        // Lerp para suavizar el retorno del retroceso
        transform.localPosition = Vector3.Lerp(transform.localPosition, _originalPosition, Time.deltaTime * _recoilSpeed);
    }

    private void HandleShoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(_cameraPlayerTransform.position, _cameraPlayerTransform.forward, out hit, _fireRange, _hittableLayers))
        {
            // Calcular la posición de spawn del agujero de bala
            Vector3 spawnPosition = hit.point + hit.normal * 0.01f; // Multiplicamos la normal por un pequeño valor para evitar que el agujero de bala esté incrustado en la superficie

            // Instanciar el agujero de bala en la posición calculada
            GameObject bulletHoleClone = Instantiate(_bulletHolePrefab, spawnPosition, Quaternion.LookRotation(hit.normal));
            Destroy(bulletHoleClone, 4f);
        }

        // Aplicar retroceso
        StartCoroutine(Recoil());
    }

    private IEnumerator Recoil()
    {
        // Desplazar el arma hacia atrás
        transform.localPosition -= transform.forward * _recoilForce;

        // Esperar un momento
        yield return new WaitForSeconds(0.1f);

        // Retornar el arma a su posición original
        // Esto ya se hace en el Update() utilizando Lerp
    }
}
