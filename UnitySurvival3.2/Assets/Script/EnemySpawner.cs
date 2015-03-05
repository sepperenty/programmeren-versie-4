using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{

    public GameObject spider;
    public GameObject superSpider;
    private GameObject[] wave1 = new GameObject[3];
    private GameObject[] wave2 = new GameObject[3];
    public int amountOfSpiders = 1;
    private bool wave2Null = true;

    // Use this for initialization
    void Start()
    {
      //GameObject spiderClone = Instantiate(spider, transform.position, transform.rotation) as GameObject;
      for (int i = 0; i < wave1.Length; i++)
      {
        wave1[i] = Instantiate(spider, transform.position + transform.right * (i * 6), transform.rotation) as GameObject;
      }

     
    }

    // Update is called once per frame
    void Update()
    {
      bool wave1Null = true;

      for (int i = 0; i < wave1.Length; i++)
      {
        if (wave1[i] != null)
        {
          wave1Null = false;
          //spiders[i] = Instantiate(spider, transform.position, transform.rotation) as GameObject;
         
        }
      
      }

      if (wave1Null && wave2Null)
      {
        wave2Null = false;
        for (int i = 0; i < wave1.Length; i++)
        {
          wave2[i] = Instantiate(superSpider, transform.position + transform.right * (i * 6), transform.rotation) as GameObject;
          
        }
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
