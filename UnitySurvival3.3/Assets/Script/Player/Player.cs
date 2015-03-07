using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    
    //Hier kunnen zaken in komen zoals HP, ...
    public float healthPoints = 10f;
    private float spiderDamage = 3f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    private void healthCheck()
    {
        if (healthPoints <= 0)                                                                  
        {
            Application.LoadLevel("StartMenu");
        }
    }
    public void hitBySpider(float bulletDamage)                                               
    {
        healthPoints -= spiderDamage;                                              
    }


    //SORRY IK MOET DOOR MAAR DIT MOET ER OOK ERGENS BIJ, CHECK BULLETSCRIPT 
    //if (hit.collider.tag == DestroyedCityConstants.SPIDER_TAG)

    //  {
    //    hit.collider.SendMessage(HIT_BY_BULLET, damage);
    //    Debug.Log("hit");
    //  }
}
