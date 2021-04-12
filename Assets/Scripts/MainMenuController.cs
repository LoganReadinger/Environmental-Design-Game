using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour{
    public Button begin;
    public Button quit;

    // Start is called before the first frame update
    void Start(){
        begin.onClick.AddListener(Begin);
        quit.onClick.AddListener(Quit);
    }

    void Begin() {
        SceneManager.LoadScene("level_doors");
    }

    void Quit() {
        Application.Quit();
    }
}
