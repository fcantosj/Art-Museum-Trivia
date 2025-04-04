using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using THSDK;

public class moving_script : MonoBehaviour
{
    public HolographicDevice device;
    public float speed = 5f;
    public Rigidbody myRigidbody;

    [SerializeField] private PlayButton playButton;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // Obtener la entrada del joystick
        Vector2 input = device.GetUser(0).GetController(0).GetJoystick(0);
        
        if (device.GetUser(0).GetController(0).GetButton(Button.Trigger)) {
            Vector3 currentRotation = transform.localEulerAngles;

            if (currentRotation.y > 180) currentRotation.y -= 360;
            if (currentRotation.x > 180) currentRotation.x -= 360;

            // Calcular la nueva rotación
            float newRotationX = currentRotation.x - input.y * speed;
            float newRotationY = currentRotation.y + input.x * speed;

            // Limitar la rotación solo en el eje X (perpendicular al suelo)
            newRotationX = Mathf.Clamp(newRotationX, -45f, 45f);

            // Ajustar a 0 si está cerca en el eje X (dentro de ±5 grados)
            if (Mathf.Abs(newRotationX) < 5f)
            {
                newRotationX = 0f;
            }

            // Ajustar a 0, 90, 180 o 270 si está cerca en el eje Y (dentro de ±5 grados)
            if (Mathf.Abs(newRotationY) < 5f)
            {
                newRotationY = 0f;
            }
            else if (Mathf.Abs(newRotationY - 90f) < 5f)
            {
                newRotationY = 90f;
            }
            else if (Mathf.Abs(newRotationY - 180f) < 5f)
            {
                newRotationY = 180f;
            }
            else if (Mathf.Abs(newRotationY - 270f) < 5f)
            {
                newRotationY = 270f;
            }

            // Aplicar la nueva rotación
            transform.localEulerAngles = new Vector3(newRotationX, newRotationY, currentRotation.z);

            // Detener el movimiento
            myRigidbody.velocity = Vector3.zero;
        } else {
            // Convertir la entrada en un Vector3 relativo a la orientación del observador
            Vector3 movement = new Vector3(input.x, 0, input.y);
            movement = transform.TransformDirection(movement);
            movement.y = 0; // Mantener el movimiento en el plano horizontal
            movement *= speed;
            
            // Aplicar la velocidad al Rigidbody
            myRigidbody.velocity = new Vector3(movement.x, myRigidbody.velocity.y, movement.z);
        }
    }

    private void OnTriggerEnter(Collider other) {
        playButton.ShowButton();
    }

    private void OnTriggerExit(Collider other) {
        playButton.HideButton();
    }

    public void Exit()
    {
        Application.Quit();
    }
}

