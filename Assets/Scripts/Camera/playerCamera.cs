using UnityEngine;

public class playerCamera : MonoBehaviour
{
    [Header("Camera Sensitivety")]
    //values for camera sensitivetiy
    public float sensX;
    public float sensY;

    //values for camera rotation
    float xRotation;
    float yRotation;

    public Transform orientataion;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //locks the cursor into place
        Cursor.lockState = CursorLockMode.Locked;
        //cursor is not visible in gameplay
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        //gets unity inputs
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        yRotation += mouseX;
        xRotation -= mouseY;

        //stops player from looking past a 90 degree angle
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        //rotates the player and model
        orientataion.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}
