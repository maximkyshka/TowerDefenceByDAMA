using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float moveSpeed = 10f; 
    public float rotationSpeed = 100f; 
    private float yaw = 0f; 
    private float pitch = 0f; 

    void Start()
    {
       
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
       
        float moveX = Input.GetAxis("Horizontal"); 
        float moveZ = Input.GetAxis("Vertical");   
        float moveY = 0f;

        
        if (Input.GetKey(KeyCode.Space))
            moveY = 1f;
        else if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            moveY = -1f;

       
        Vector3 movement = transform.right * moveX + transform.forward * moveZ + Vector3.up * moveY;
        transform.position += movement * moveSpeed * Time.deltaTime;

       
        yaw += rotationSpeed * Input.GetAxis("Mouse X") * Time.deltaTime;
        pitch -= rotationSpeed * Input.GetAxis("Mouse Y") * Time.deltaTime;

        
        pitch = Mathf.Clamp(pitch, -90f, 90f);

        
        transform.eulerAngles = new Vector3(pitch, yaw, 0f);

        
        if (Input.GetKeyDown(KeyCode.B))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
