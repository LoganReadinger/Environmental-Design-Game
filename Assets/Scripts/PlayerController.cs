using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour{
    //Movement
    public float movementSpeed;
    
    //Jumping
    public float jumpHeight = 5f;
    private float heightValue;
    private bool canJump = true;

    //Mouse Movement
    public float horizontalSensitivity = 100f;
    public float verticalSensitivity = 100f;
    private float yaw = 0.0f;
    private float pitch = 0.0f;

    //Gravity
    public float gravitationalPull = 9.8f;
    
    //Objects
    private Rigidbody rb;
    public new GameObject camera;

    //Raycast
    private RaycastHit hit;

    //UI
    private GameObject canvas;
    private UIController ui;
    private static string code;

    //Trigger
    private TriggerController triggerController;

    //----------------------------------START-------------------------------------------
    void Start(){
        rb = GetComponent<Rigidbody>();
        heightValue = jumpHeight;
        
        // Hide cursor
        Cursor.visible = false;

        canvas = GameObject.Find("Canvas");
        ui = canvas.GetComponent<UIController>();
        triggerController = this.GetComponent<TriggerController>();
    }

    //----------------------------------UPDATE-------------------------------------------
    void Update() {
        //If game is not paused, do physics
        if(ui.gamePaused == false) {
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
            pitch = Mathf.Min(60, Mathf.Max(-60, pitch - Input.GetAxis("Mouse Y")));

            //Up-Down
            transform.eulerAngles = new Vector3(0.0f, yaw, 0.0f);
            camera.transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);

            //----------------------------------Interaction-------------------------------------------
            //If the ray collides
            if(Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, 1.0f)) {
                Debug.DrawRay(camera.transform.position, camera.transform.forward * 1.0f, Color.green);

                //If ray collides with trigger
                if(hit.collider.isTrigger) {
                    ui.interact.enabled = true;

                    //If player presses E
                    if(Input.GetKey(KeyCode.E)) {
                        string triggerName = hit.collider.name;

                        //Active Trigger and return decision
                        code += triggerController.Trigger(triggerName); 
                    }
                }
            } else {
                Debug.DrawRay(camera.transform.position, camera.transform.forward * 1.0f, Color.red);

                ui.interact.enabled = false;
            }
        }
    }

    
}
