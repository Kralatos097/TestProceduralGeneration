using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float speed = 10;
    
    /*public float horizontalSpeed = 5f;
    public float verticalSpeed = 1.5f;
    private float xRotation = 0.0f;
    private float yRotation = 0.0f;
    private Camera cam;*/
    private Rigidbody rb;
    
    // Start is called before the first frame update
    void Start()
    {
        /*cam = Camera.main;*/
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float movX = Input.GetAxis("Horizontal");
        float movy = Input.GetAxis("Vertical");
        
        //transform.Translate(new Vector3(movX, 0, movy) * speed * Time.deltaTime);
        
        rb.MovePosition(transform.position + new Vector3(movX, 0, movy) * speed * Time.deltaTime);/*
        
        float mouseX = Input.GetAxis("Mouse X") * horizontalSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * verticalSpeed;
 
        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90, 90);
 
        cam.transform.eulerAngles = new Vector3(xRotation, yRotation, 0.0f);
        transform.eulerAngles = new Vector3(0, yRotation, 0.0f);*/
    }
}
