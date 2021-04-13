using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationController : MonoBehaviour {
    public Dictionary<string, Vector3> locations = new Dictionary<string, Vector3>();

    void Start(){
        //----------------------------------Locations-------------------------------------------
        // "LocationName", Vector3(X,Y,Z)
        // Level_Doors
        locations.Add("lvl_doors_room1", new Vector3(-44.25f, 3.25f, -23f));
        locations.Add("lvl_doors_room2", new Vector3(-33.00f, 3.25f, -23f));
        locations.Add("lvl_doors_room3", new Vector3(-21.25f, 3.25f, -23f));
        locations.Add("lvl_doors_room4", new Vector3( -9.75f, 3.25f, -23f));
        locations.Add("lvl_doors_room5", new Vector3(  2.50f, 3.25f, -23f));

        // Level_Structures
        locations.Add("lvl_structures_room1",  new Vector3(-44.25f, 2.75f, -51.25f));
        locations.Add("lvl_structures_room2a", new Vector3(-25.75f, 2.75f, -45.00f));
        locations.Add("lvl_structures_room2b", new Vector3(-25.75f, 2.75f, -59.00f));
        locations.Add("lvl_structures_room3",  new Vector3( -2.75f, 2.75f, -51.25f));
        locations.Add("lvl_structures_room4a", new Vector3( 17.50f, 2.75f, -44.75f));
        locations.Add("lvl_structures_room4b", new Vector3( 17.50f, 2.75f, -61.75f));
        locations.Add("lvl_structures_room5",  new Vector3( 42.25f, 2.75f, -51.25f));
        locations.Add("lvl_structures_room6",  new Vector3( 63.50f, 2.75f, -51.25f));
        locations.Add("lvl_structures_room7",  new Vector3( 83.50f, 2.75f, -51.25f));

        //Level_Nature
        locations.Add("lvl_nature", new Vector3(12.50f, 2.25f, -8.25f));

    }
}
