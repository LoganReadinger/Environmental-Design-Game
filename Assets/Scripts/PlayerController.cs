using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour{
    public float movementSpeed = 10f;
    public float jumpHeight = 5f;
    float heightValue;
    public float horizontalSensitivity = 100f;
    public float verticalSensitivity = 100f;
    public float gravitationalPull = 9.8f;
    private float yaw = 0.0f;
    private float pitch = 0.0f;

    bool canJump = true;
    bool paused = false;

    Rigidbody rb;
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
            rb.AddRelativeForce(Vector3.forward * movementSpeed);
            
        }

        //Left
        if(Input.GetKey(KeyCode.A)) {
            rb.AddRelativeForce(Vector3.left * movementSpeed);
        }

        //Back
        if(Input.GetKey(KeyCode.S)) {
            rb.AddRelativeForce(Vector3.back * movementSpeed);
        }
        //Right
        if(Input.GetKey(KeyCode.D)) {
            rb.AddRelativeForce(Vector3.right * movementSpeed);
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
