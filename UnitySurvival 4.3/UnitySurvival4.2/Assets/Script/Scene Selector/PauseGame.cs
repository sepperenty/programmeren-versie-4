using UnityEngine;
using System.Collections;

public class PauseGame : MonoBehaviour {

    public GameObject canvas;
    private GameObject foundPlayer;
    private GameObject foundCamera;
    private bool pauseBool = false;

    //Screen.showCursor = !Screen.showCursor;
	// Use this for initialization
	void Start () {
        canvas.SetActive(false);
        foundPlayer = GameObject.Find("Player");
        foundCamera = GameObject.Find("Main Camera");
        Screen.showCursor = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //pauseTheGame();
            pauseBool =! pauseBool; // toggles onoff at each click
            if (pauseBool)
            {
                pauseTheGame();
                Screen.showCursor = true;
            }
            else
            {
                resumeTheGame();
                Screen.showCursor = false;
            }
        }
	}

    public void pauseTheGame()
    {
        //freeze tijd, mogelijkheid om te schieten, camerax en y
        Debug.Log("Pause");
        Time.timeScale = 0.0f;
        canvas.SetActive(true);
        foundPlayer.GetComponent<PlayerShoot>().enabled = false;
        foundPlayer.GetComponent<MouseLook>().enabled = false;
        foundCamera.GetComponent<MouseLook>().enabled = false;
    }
    public void resumeTheGame()
    {
        //resume tijd, mogelijkheid om te schieten, camerax en y
        Time.timeScale = 1.0f;
        canvas.SetActive(false);
        foundPlayer.GetComponent<PlayerShoot>().enabled = true;
        foundPlayer.GetComponent<MouseLook>().enabled = true;
        foundCamera.GetComponent<MouseLook>().enabled = true;
    }
    public void restartTheGame()
    {
        Application.LoadLevel("destroyed_city");
        resumeTheGame();
    }
    public void loadMenu()
    {
        Application.LoadLevel("StartMenu");
        resumeTheGame();
    }
}
