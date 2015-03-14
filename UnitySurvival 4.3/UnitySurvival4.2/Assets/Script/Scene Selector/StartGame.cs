using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour
{
    //2 methode die aan de buttons gekoppeld zijn
    public void startTheGame()
    {
        Application.LoadLevel("destroyed_city");
    }
    public void quitTheGame()
    {
        Application.Quit();
    }
}

