using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScreenCanvas : MonoBehaviour {

    Text txtHealthPoints;
    Player PlayerHealth = new Player();

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	txtHealthPoints = GetComponent<Text>(); //reach textbox on canvas
    txtHealthPoints.text = PlayerHealth.HealthPoints.ToString(); //give the propperty HealthPoints to the textbox
	}
}
