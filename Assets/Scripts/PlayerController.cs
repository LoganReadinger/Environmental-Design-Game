using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour{
    public float movementSpeed;
    
    public float jumpHeight = 5f;
    private float heightValue;
    private bool canJump = true;

    public float horizontalSensitivity = 100f;
    public float verticalSensitivity = 100f;
    private float yaw = 0.0f;
    private float pitch = 0.0f;

    public float gravitationalPull = 9.8f;
    
    //private bool paused = false;

    private Rigidbody rb;
    public new GameObject camera;

    //Start Method
    void Start(){
        rb = GetComponent<Rigidbody>();
        heightValue = jumpHeight;
        Cursor.visible = false;
    }

    //Update Method
    void Update() {
        //----------------------------------JUMPING-------------------------------------------
        //Allow 1 Jump
        if(Input.GetKeyDown(KeyCode.Space) && canJump) {
            heightValue = jumpHeight;
            canJump = false;
        }

        //Jumping
        if(heightValue <= 0) {
            canJump = true;
        } else if(heightValue > 0 && !canJump) {
            rb.AddForce(new Vector3(0, heightValue, 0));
            heightValue -= 1f;
        }

        //Constant Gravity
        rb.AddForce(new Vector3(0, -gravitationalPull, 0));

        //----------------------------------MOVEMENT-------------------------------------------
        //Forward
        if(Input.GetKey(KeyCode.W)) {
            rb.AddRelativeForce(new Vector3(0, 0, movementSpeed));
            
        }

        //Left
        if(Input.GetKey(KeyCode.A)) {
            rb.AddRelativeForce(new Vector3(-movementSpeed, 0, 0));
        }

        //Back
        if(Input.GetKey(KeyCode.S)) {
            rb.AddRelativeForce(new Vector3(0, 0, -movementSpeed));
        }
        //Right
        if(Input.GetKey(KeyCode.D)) {
            rb.AddRelativeForce(new Vector3(movementSpeed, 0, 0));
        }

        //----------------------------------TURNING-------------------------------------------
        //Left-Right
        yaw += horizontalSensitivity * Input.GetAxis("Mouse X");
        //pitch -= verticalSensitivity * Input.GetAxis("Mouse Y");
        pitch = Mathf.Min(60, Mathf.Max(-60, pitch - Input.GetAxis("Mouse Y")));
        
        transform.eulerAngles = new Vector3(0.0f, yaw, 0.0f);
        camera.transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
        

        //----------------------------------Pause-------------------------------------------
        //if(Input.GetKeyDown(KeyCode.Escape)) {
        //    if(paused) {
        //        Time.timeScale = 0f;
        //        paused = true;
        //    } else {
        //        Time.timeScale = 1f;
        //        paused = false;
        //    }
        //}
    }
}
