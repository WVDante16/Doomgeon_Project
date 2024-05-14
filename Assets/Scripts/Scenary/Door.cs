using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    //Variables publicas
    public bool isOpen = false;

    //Variables privadas
    private float speed = 1f;
    [SerializeField] private Vector3 slideDirection = Vector3.back;
    private float slideAmount = 1.9f;
    private Vector3 startPosition;
    private Vector3 forward;
    private Coroutine AnimationCoroutine;

    private void Awake()
    {
        //Setear posiciones iniciales y definir frente de la puerta
        forward = transform.right;
        startPosition = transform.position;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.O)) 
        {
            Open();
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            Close();
        }
    }

    //Funcion para abrir puerta
    public void Open()
    {
        if (!isOpen)
        {
            if (AnimationCoroutine != null)
            {
                StopCoroutine(AnimationCoroutine);
            }

            AnimationCoroutine = StartCoroutine(DoSlidingOpen());
        }
    }

    //Funcion para cerrar la puerta
    public void Close()
    {
        if (isOpen)
        {
            if (AnimationCoroutine != null)
            {
                StopCoroutine(AnimationCoroutine);
            }

            AnimationCoroutine = StartCoroutine(DoSlidingClose());
        }
    }

    //Corrutina para abrir la puerta
    private IEnumerator DoSlidingOpen()
    {
        Vector3 endPosition = startPosition + slideAmount * slideDirection;
        Vector3 StartPosition = transform.position;

        float time = 0;
        isOpen = true;

        //Mover la puerta hasta que pase un segundo
        while(time < 1)
        {
            transform.position = Vector3.Lerp(StartPosition, endPosition, time);
            yield return null;
            time += Time.deltaTime * speed;
        }
    }

   //Corrutina para cerrar la puerta
   private IEnumerator DoSlidingClose()
    {
        Vector3 endPosition = startPosition;
        Vector3 StartPosition = transform.position;
        
        float time = 0;
        isOpen = false;

        //Mover la puerta hasta que pase un segundo
        while (time < 1)
        {
            transform.position = Vector3.Lerp(StartPosition, endPosition, time);
            yield return null;
            time += Time.deltaTime * speed;
        }
    }
}
