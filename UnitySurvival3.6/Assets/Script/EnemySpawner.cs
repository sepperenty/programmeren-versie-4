using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{

    public GameObject spider;
    private GameObject[] spiders = new GameObject[3];   //array van gameobjects
    public int amountOfSpiders = 1;

    // Use this for initialization
    void Start()
    {
      //GameObject spiderClone = Instantiate(spider, transform.position, transform.rotation) as GameObject;
      for (int i = 0; i < spiders.Length; i++)
      {
        spiders[i] = Instantiate(spider, transform.position + transform.right * (i * 6), transform.rotation) as GameObject; //6 omdat deze dan naast elkaar komen
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

      foreach (GameObject initSpider in spiders)
      {
          
          
          
          
          if (initSpider == null)
          {
              for (int i = 0; i < length; i++)
              {
                  
              }
          }
      }


        ////spawns enemies in waves, once all dead, spawns more
        //      private bool waveSpawner = false;
        //      public int totalEnemy = 10;
	    //      private int numEnemy = 0;
        //      private int spawnedEnemy = 0;
        //
        //      public int totalWaves = 5;      //max aantal waves
	    //      private int numWaves = 0;       //begin aantal waves
        //
        //        if(numWaves < totalWaves + 1)
        //        {
        //            if (waveSpawn)
        //            {
        //                //spawn enemy
        //                spawnEnemy();
        //            }
        //            if (numEnemy == 0)
        //            {
        //                //zet wave spawner aan
        //                waveSpawner = true;
        //                //ga naar volgende wave
        //                numWaves++;
        //            }
        //            if(numEnemy == totalEnemy)
        //            {
        //                //zet wavespawner terug op false
        //                waveSpawner = false;
        //            }
        //        }
        //
        //      private void spawnEnemy()
        //      {
        //          GameObject Enemy = (GameObject)Instantiate(Enemies[enemyLevel], gameObject.transform.position, Quaternion.identity);
        //          //verhoog het totale aantal enemies die gaan spawnen en die gespawned zijn 
        //          numEnemy++;
        //          spawnedEnemy++;
        //      }
        //
        //    


    }
}
