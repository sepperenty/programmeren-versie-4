using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    private float healthPoints = 10f;
    public GameObject bloodCanvas;
    public GameObject screenCanvas;

    public float HealthPoints //accessable for canvas READ-ONLY
    {
        get { return healthPoints; }
        set 
        {
            if ((value > 0) && (value < 13))
            {
                healthPoints = value;
            }
        }
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        HealthCheck();
    }

    private void HealthCheck()
    {
        if (healthPoints <= 0)
        {
            Die();
        }
    }
    public void HitBySpider(float spiderDamage)
    {
        healthPoints -= spiderDamage;
        Debug.Log(healthPoints);
    }

    private void Die()
    {
        Application.LoadLevel(DestroyedCityConstants.START_SCENE);
    }
}
