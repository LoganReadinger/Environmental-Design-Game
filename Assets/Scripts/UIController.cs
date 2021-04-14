using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour{
    public Text interact;
    public Text paused;
    public Text FPS;
    public GameObject pauseMenuPanel;
    public GameObject blackScreen;
    public Button resume;
    public Button quit;
    public Text score;

    public bool gamePaused;
    public bool dim;
    private int fpsCount;
    private float fpsRefreshRate = 0.5f;
    private float timer;

    // Start is called before the first frame update
    void Start(){
        interact.enabled = false;
        paused.enabled = false;
        gamePaused = false;
        pauseMenuPanel.SetActive(false);
        resume.gameObject.SetActive(false);
        quit.gameObject.SetActive(false);
        FPS.enabled = true;

        resume.onClick.AddListener(ResumeGame);
        quit.onClick.AddListener(QuitGame);
    }

    // Update is called once per frame
    void Update(){
        //----------------------------------FPS Counter-------------------------------------------
        if(Time.unscaledTime > timer) {
            fpsCount = (int)(1f / Time.unscaledDeltaTime);
            FPS.text = "FPS: " + fpsCount;
            timer = Time.unscaledTime + fpsRefreshRate;
        }

        //----------------------------------Pause-------------------------------------------
        if(Input.GetKeyDown(KeyCode.Escape)) {
            if(gamePaused == false) {
                PauseGame();

            } else {
                ResumeGame();
            }
        }
    }

    void ResumeGame() {
        Time.timeScale = 1f;
        gamePaused = false;
        paused.enabled = false;
        pauseMenuPanel.SetActive(false);
        resume.gameObject.SetActive(false);
        quit.gameObject.SetActive(false);
    }

    void PauseGame() {
        Time.timeScale = 0f;
        gamePaused = true;
        paused.enabled = true;
        pauseMenuPanel.SetActive(true);
        resume.gameObject.SetActive(true);
        quit.gameObject.SetActive(true);
    }

    void QuitGame() {
        SceneManager.LoadScene("level_mainmenu");
    }

}
