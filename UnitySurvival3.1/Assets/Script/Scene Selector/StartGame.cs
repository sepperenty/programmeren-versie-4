using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour
{

    public void startTheGame()
    {
        Debug.Log("Button was pressed");
        Application.LoadLevel("destroyed_city");
    }
}

