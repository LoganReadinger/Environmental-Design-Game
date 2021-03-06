using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerController : MonoBehaviour{
    public GameObject path1_left1;
    public GameObject path1_left2;
    public GameObject path1_right1;
    public GameObject path1_right2;

    public GameObject path2_left1;
    public GameObject path2_left2;
    public GameObject path2_right1;
    public GameObject path2_right2;

    public GameObject path3_left1;
    public GameObject path3_left2;
    public GameObject path3_right1;
    public GameObject path3_right2;

    private LocationController locationController;
    private Transform player;

    // Start is called before the first frame update
    void Start(){
        //----------------------------------lvl_nature fences-------------------------------------------
        if(SceneManager.GetActiveScene().name == "level_nature") {
            path1_left1.SetActive(false);
            path1_left2.SetActive(false);
            path1_right1.SetActive(false);
            path1_right2.SetActive(false);

            path2_left1.SetActive(false);
            path2_left2.SetActive(false);
            path2_right1.SetActive(false);
            path2_right2.SetActive(false);
            
            path3_left1.SetActive(false);
            path3_left2.SetActive(false);
            path3_right1.SetActive(false);
            path3_right2.SetActive(false);
        }

        locationController = this.GetComponent<LocationController>();
        player = this.GetComponent<Transform>();
    }


    //The Trigger method uses the trigger name and scene name to teleport the player to the appropritate room/level
    public string Trigger(string triggerName) {
        //Get current scene name
        string sceneName = SceneManager.GetActiveScene().name;
        //Debug.Log(sceneName + " : " + triggerName);

        //---------Level_Doors---------
        if(sceneName == "level_doors") {
            //Room 1
            if(triggerName == "lvl_doors_room1_left") {
                player.position = locationController.locations["lvl_doors_room2"];
                return "0";
            } else if(triggerName == "lvl_doors_room1_right") {
                player.position = locationController.locations["lvl_doors_room2"];
                return "1";
            }

            //Room 2
            if(triggerName == "lvl_doors_room2_left") {
                player.position = locationController.locations["lvl_doors_room3"];
                return "0";
            } else if(triggerName == "lvl_doors_room2_right") {
                player.position = locationController.locations["lvl_doors_room3"];
                return "1";
            }
            
            //Room 3
            if(triggerName == "lvl_doors_room3_left") {
                player.position = locationController.locations["lvl_doors_room4"];
                return "0";
            } else if(triggerName == "lvl_doors_room3_right") {
                player.position = locationController.locations["lvl_doors_room4"];
                return "1";
            }

            //Room 4
            if(triggerName == "lvl_doors_room4_left") {
                player.position = locationController.locations["lvl_doors_room5"];
                return "0";
            } else if(triggerName == "lvl_doors_room4_right") {
                player.position = locationController.locations["lvl_doors_room5"];
                return "1";
            }

            //Room 5
            if(triggerName == "lvl_doors_room5_left") {
                player.position = locationController.locations["lvl_structures_room1"];
                SceneManager.LoadScene("level_structures");
                return "0";
            } else if(triggerName == "lvl_doors_room5_right") {
                player.position = locationController.locations["lvl_structures_room1"];
                SceneManager.LoadScene("level_structures");
                return "1";
            }
        }

        //---------Level_Structures---------
        if(sceneName == "level_structures"){
            //Room 1
            if(triggerName == "lvl_structures_room1_left") {
                player.position = locationController.locations["lvl_structures_room2b"];
                return "0";
            } else if(triggerName == "lvl_structures_room1_right") {
                player.position = locationController.locations["lvl_structures_room2a"];
                return "1";
            }

            //Room 2a
            if(triggerName == "lvl_structures_room2a_left") {
                player.position = locationController.locations["lvl_structures_room3"];
                return "0";
            } else if(triggerName == "lvl_structures_room2a_right") {
                player.position = locationController.locations["lvl_structures_room3"];
                return "1";
            }

            //Room 2b
            if(triggerName == "lvl_structures_room2b_left") {
                player.position = locationController.locations["lvl_structures_room3"];
                return "0";
            } else if(triggerName == "lvl_structures_room2b_right") {
                player.position = locationController.locations["lvl_structures_room3"];
                return "1";
            }

            //Room 3
            if(triggerName == "lvl_structures_room3_left") {
                player.position = locationController.locations["lvl_structures_room4b"];
                return "0";
            } else if(triggerName == "lvl_structures_room3_right") {
                player.position = locationController.locations["lvl_structures_room4a"];
                return "1";
            }

            //Room 4a
            if(triggerName == "lvl_structures_room4a_left") {
                player.position = locationController.locations["lvl_structures_room5"];
                return "0";
            } else if(triggerName == "lvl_structures_room4a_right") {
                player.position = locationController.locations["lvl_structures_room5"];
                return "1";
            }

            //Room 4b
            if(triggerName == "lvl_structures_room4b_left") {
                player.position = locationController.locations["lvl_structures_room5"];
                return "0";
            } else if(triggerName == "lvl_structures_room4b_right") {
                player.position = locationController.locations["lvl_structures_room5"];
                return "1";
            }

            //Room 5
            if(triggerName == "lvl_structures_room5_left") {
                player.position = locationController.locations["lvl_structures_room6"];
                return "0";
            } else if(triggerName == "lvl_structures_room5_right") {
                player.position = locationController.locations["lvl_structures_room6"];
                return "1";
            }

            //Room 6
            if(triggerName == "lvl_structures_room6_left") {
                player.position = locationController.locations["lvl_structures_room7"];
                return "0";
            } else if(triggerName == "lvl_structures_room6_right") {
                player.position = locationController.locations["lvl_structures_room7"];
                return "1";
            }

            //Room 7
            if(triggerName == "lvl_structures_room7_left") {
                player.position = locationController.locations["lvl_nature"];
                SceneManager.LoadScene("level_nature");
                return "0";
            } else if(triggerName == "lvl_structures_room7_right") {
                player.position = locationController.locations["lvl_nature"];
                SceneManager.LoadScene("level_nature");
                return "1";
            }
        }

        //---------Level_Nature---------
        if(sceneName == "level_nature") {
            //Path 1
            if(triggerName == "lvl_nature_path1_left") {
                path1_left1.SetActive(true);
                path1_right1.SetActive(true);
                path1_right2.SetActive(true);

                return "0";
            } else if(triggerName == "lvl_nature_path1_right") {
                path1_left1.SetActive(true);
                path1_left2.SetActive(true);
                path1_right1.SetActive(true);

                return "1";
            }

            //Path 2
            if(triggerName == "lvl_nature_path2_left") {
                path2_left1.SetActive(true);
                path2_right1.SetActive(true);
                path2_right2.SetActive(true);

                return "0";
            } else if(triggerName == "lvl_nature_path2_right") {
                path2_left1.SetActive(true);
                path2_left2.SetActive(true);
                path2_right1.SetActive(true);

                return "1";
            }

            //Path 3
            if(triggerName == "lvl_nature_path3_left") {
                path3_left1.SetActive(true);
                path3_right1.SetActive(true);
                path3_right2.SetActive(true);

                return "0";
            } else if(triggerName == "lvl_nature_path3_right") {
                path3_left1.SetActive(true);
                path3_left2.SetActive(true);
                path3_right1.SetActive(true);

                return "1";
            }

            //Path 4
            if(triggerName == "lvl_nature_path4_left") {
                return "1";
            }

            if(triggerName == "lvl_nature_results") {
                SceneManager.LoadScene("level_code");
            }
        }

        return null;
    }
}
