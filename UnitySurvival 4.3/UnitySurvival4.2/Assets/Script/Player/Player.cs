using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    public float healthPoints = 10f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        healthCheck();
    }

    private void healthCheck()
    {
        if (healthPoints <= 0)
        {
            die();
        }
    }
    public void HitBySpider(float spiderDamage)
    {
        healthPoints -= spiderDamage;
        Debug.Log(healthPoints);
    }

    private void die()
    {
        Application.LoadLevel(DestroyedCityConstants.START_SCENE);
    }
}
