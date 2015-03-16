using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour
{
    //2 methode die aan de buttons gekoppeld zijn
    public void StartTheGame()
    {
        Application.LoadLevel("destroyed_city");
    }
    public void QuitTheGame()
    {
        Application.Quit();
    }
}

