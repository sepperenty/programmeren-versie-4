using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour
{

    public void startTheGame()
    {
        Application.LoadLevel("destroyed_city");
    }
    public void quitTheGame()
    {
        Application.Quit();
    }
}

