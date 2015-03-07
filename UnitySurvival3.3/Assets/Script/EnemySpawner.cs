using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{

    public GameObject spider;
    private GameObject[] spiders = new GameObject[3];
    public int amountOfSpiders = 1;

    // Use this for initialization
    void Start()
    {
      //GameObject spiderClone = Instantiate(spider, transform.position, transform.rotation) as GameObject;
      for (int i = 0; i < spiders.Length; i++)
      {
        spiders[i] = Instantiate(spider, transform.position + transform.right * (i * 6), transform.rotation) as GameObject;
      }

     
    }

    // Update is called once per frame
    void Update()
    {
      bool allNull = true;

      for (int i = 0; i < spiders.Length; i++)
      {
        if (spiders[i] != null)
        {
          allNull = false;
          //spiders[i] = Instantiate(spider, transform.position, transform.rotation) as GameObject;
         
        }
      
      }

      if (allNull)
      { 
        //wave2

      }
      //foreach (GameObject spin in spiders)
      //{
      //  if (spin == null)
      //  {
      //    spin = Instantiate(spider, transform.position, transform.rotation) as GameObject;
      //  }
      //}
    }
}
