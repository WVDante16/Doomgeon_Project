using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public Estados estado; //variable que hace referencia al enum de abajo

    /*variables de distancia que cambiaran el estado del enemigo*/
    public float distanciaSeguir;
    public float distanciaAtacar;
    public float distanciaEscapar;
    public bool estaVivo = true;

    /*variables del jugador*/
    public Transform target;
    public float distancia;

    public void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine("CalcularDistancia");
    }

    /*funcion que se ejecuta despues del update*/
    private void LateUpdate()
    {
        ChecarEstado();
    }

    /*funcion que ejecuta cada logica de cada estado*/
    public void ChecarEstado()
    {
        switch (estado)
        {
            case Estados.Idle:
                EstadoIdle();
                break;
            case Estados.Seguir:
                EstadoSeguir();
                break;
            case Estados.Atacar:
                EstadoAtacar();
                break;
            case Estados.Muerto:
                EstadoMuerto();
                break;
            default:
                break;
        }
    }

    /*funcion principal para cambiar de estado*/
    public void CambiarEstado(Estados e)
    {
        switch (e)
        {
            case Estados.Idle:
                break;
            case Estados.Seguir:
                break;
            case Estados.Atacar:
                break;
            case Estados.Muerto:
                estaVivo = false;
                break;
            default:
                break;
        }
        estado = e;
    }

    /*funcion que dibuja esferas en el editor para visualizar el rango de cada estado*/
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, distanciaAtacar);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, distanciaSeguir);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, distanciaEscapar);
    }

    /*-----------metodos de los estado-----------*/

    /*Funcion basica de Idle*/
    public virtual void EstadoIdle()
    {
        if (distancia < distanciaSeguir)
        {
            CambiarEstado(Estados.Seguir);
        }
    }

    /*Funcion basica de seguit*/
    public virtual void EstadoSeguir()
    {
        if (distancia < distanciaAtacar)
        {
            CambiarEstado(Estados.Atacar);
        }
        else if (distancia > distanciaEscapar)
        {
            CambiarEstado(Estados.Idle);
        }
    }

    /*Funcion basica de atacar*/
    public virtual void EstadoAtacar()
    {
        if (distancia > distanciaAtacar + 0.4f)
        {
            CambiarEstado(Estados.Seguir);
        }
    }

    /*Funcion basica de muerte*/
    public virtual void EstadoMuerto()
    {

    }

    IEnumerator CalcularDistancia()
    {
        while (estaVivo)
        {
            if (target != null)
            {
                distancia = Vector3.Distance(transform.position, target.position);
                yield return new WaitForSeconds(0.3f);
            }
        }
    }
}


/*enumearator de todos los estados que tiene la inteligencia artificial*/
public enum Estados
{
    Idle = 0,
    Seguir = 1,
    Atacar = 2,
    Muerto = 3
}

