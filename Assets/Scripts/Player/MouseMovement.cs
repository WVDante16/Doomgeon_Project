using UnityEngine;

public class MouseMovement : MonoBehaviour
{
    //Variables publicas
    public float mouseSensitivity = 500f;
    public float topClamp = -90f;
    public float bottomClamp = 90f;

    //Variables privadas
    private float xRotation = 0f;
    private float yRotation = 0f;

    private void Start()
    {
        //Bloqueando el cursor al centro de la pantalla y hacerlo invisible
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        //Obtener los inputs del mouse
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        //Rotacion alderedor del eje X y Y
        xRotation -= mouseY;
        yRotation += mouseX;

        //Delimitar la rotacion
        xRotation = Mathf.Clamp(xRotation, topClamp, bottomClamp);

        //Aplicar las rotaciones al transform del player
        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
    }
}
