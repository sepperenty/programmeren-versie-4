using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{

    public GameObject spider;
    private GameObject spiderClone;
    public int amountOfSpiders = 1;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            spiderClone = Instantiate(spider, transform.position * 50, transform.rotation) as GameObject;
        }
    }
}
