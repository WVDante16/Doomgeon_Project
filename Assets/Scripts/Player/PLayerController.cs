using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

// Requiere que el GameObject tenga un componente CharacterController
[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    // Referencias a otros scripts y componentes
    public Player player;
    public NPCInteract npcInteract;

    // Referencias a la cámara del jugador y variables de movimiento
    public Camera playerCamera;
    public float walkSpeed = 6f;
    public float runSpeed = 12f;
    public float jumpPower = 7f;
    public float gravity = 11f;
    public float lookSpeed = 2f;
    public float lookXLimit = 45f;
    public float interactionRange = 5.0f;

    // Variables internas de control de movimiento
    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0f;
    public bool canMove = true;

    // Referencia al CharacterController del jugador
    CharacterController characterController;

    // Se llama al inicio de la escena
    void Start()
    {
        // Obtiene el componente CharacterController
        characterController = GetComponent<CharacterController>();
        // Bloquea el cursor en el centro de la pantalla y lo oculta
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Se llama una vez por frame
    void Update()
    {
        #region Handles Movement
        // Obtiene la dirección adelante y derecha del jugador
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        // Presiona Left Shift para correr
        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        // Calcula la velocidad actual en los ejes X e Y según si el jugador puede moverse
        float curSpeedX = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = moveDirection.y;
        // Calcula la dirección de movimiento del jugador
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);
        #endregion

        #region Handles Jumping
        // Detecta si el jugador está saltando y puede moverse
        if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
        {
            moveDirection.y = jumpPower;
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }

        // Aplica la gravedad si el jugador no está en el suelo
        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }
        #endregion

        #region Handles Rotation
        // Mueve el jugador según la dirección calculada
        characterController.Move(moveDirection * Time.deltaTime);

        // Gestiona la rotación del jugador si puede moverse
        if (canMove)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }
        #endregion

        #region Handles SwitchWeapon
        // Cambia el arma en la mano del jugador al presionar los botones correspondientes
        if (Input.GetButtonDown("Weapon1"))
        {
            player.WeaponInHand = player.so_player.Weapons[0];
            player.playerUI.UpdateAmmo(player.WeaponInHand.Magazine, player.WeaponInHand.AmmoTotal);
        }

        if (Input.GetButtonDown("Weapon2"))
        {
            player.WeaponInHand = player.so_player.Weapons[1];
            player.playerUI.UpdateAmmo(player.WeaponInHand.Magazine, player.WeaponInHand.AmmoTotal);
        }

        if (Input.GetButtonDown("Weapon3"))
        {
            player.WeaponInHand = player.so_player.Weapons[2];
            player.playerUI.UpdateAmmo(player.WeaponInHand.Magazine, player.WeaponInHand.AmmoTotal);
        }

        if (Input.GetButtonDown("Weapon4"))
        {
            player.WeaponInHand = player.so_player.Weapons[3];
            player.playerUI.UpdateAmmo(player.WeaponInHand.Magazine, player.WeaponInHand.AmmoTotal);
        }
        #endregion

        #region Handles Recharge
        // Recarga el arma del jugador al presionar el botón de recarga
        if (Input.GetButtonDown("Recharge") && player.WeaponInHand.MagazineCapacity > player.WeaponInHand.Magazine)
        {
            player.WeaponInHand.AmmoTotal -= (player.WeaponInHand.MagazineCapacity - player.WeaponInHand.Magazine);
            player.WeaponInHand.Magazine += (player.WeaponInHand.MagazineCapacity - player.WeaponInHand.Magazine);

            Debug.Log($"R");

            player.playerUI.UpdateAmmo(player.WeaponInHand.Magazine, player.WeaponInHand.AmmoTotal);
        }
        #endregion

        #region Handles InteractionButton
        // Gestiona la interacción al presionar el botón de interacción
        if (Input.GetButtonDown("Interact"))
        {
            // Crear un rayo desde la posición del cursor del ratón
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Realizar el raycast con el alcance especificado
            if (Physics.Raycast(ray, out hit, interactionRange))
            {
                // Si el rayo golpea un objeto con el tag "NPC" y el jugador puede moverse
                if (hit.collider.CompareTag("NPC") && canMove == true)
                {
                    // Iniciar el diálogo con el NPC y mostrar la caja de texto
                    npcInteract.NPCDialogue(player.playerUI.textBox);
                    player.playerUI.textBoxBG.SetActive(true);
                    // Deshabilitar el movimiento del jugador
                    canMove = false;
                }
                // Si el rayo golpea un objeto con el tag "NPC" y el jugador no puede moverse
                else if (hit.collider.CompareTag("NPC") && canMove == false)
                {
                    // Ocultar la caja de texto y permitir el movimiento del jugador
                    player.playerUI.textBoxBG.SetActive(false);
                    canMove = true;
                }

                // Si el rayo golpea un objeto con el tag "Key"
                if (hit.collider.CompareTag("Key"))
                {
                    // Intentar obtener el componente GroundObjects del objeto golpeado
                    GroundObjects keyObject = hit.collider.GetComponent<GroundObjects>();

                    // Verificar si el componente GroundObjects se encontró en el objeto
                    if (keyObject != null)
                    {
                        // Agregar la llave al inventario
                        keyObject.addKey(keyObject.KeyName);
                    }
                    else
                    {
                        Debug.LogWarning("El objeto con tag 'Key' no tiene un componente GroundObjects.");
                    }
                }

                // Si el rayo golpea un objeto con el tag "DropWeapon"
                if (hit.collider.CompareTag("DropWeapon"))
                {
                    // Intentar obtener el componente GroundObjects del objeto golpeado
                    GroundObjects dropWeapon = hit.collider.GetComponent<GroundObjects>();

                    // Verificar si el componente GroundObjects se encontró en el objeto
                    if (dropWeapon != null)
                    {
                        // Agregar el arma al inventario
                        dropWeapon.addDropWeapon(dropWeapon.DropWeapon);
                    }
                    else
                    {
                        Debug.LogWarning("El objeto con tag 'DropWeapon' no tiene un componente GroundObjects.");
                    }
                }
            }
        }
        #endregion
    }
}