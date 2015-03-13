using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{

    
    public GameObject[] wave1;
    public GameObject[] wave2;
    public GameObject[] wave3;
    public GameObject[] wave4;
    public GameObject[] wave5;

    private bool wave2CanStart = true;
    private bool wave3CanStart = true;
    private bool wave4CanStart = true;
    private bool wave5CanStart = true;

    private int waveLength = 5;
    private int waveInterval = 2;

    public bool isWaveEmpty( GameObject[]wave) 
    {
        bool ArrayIsNull = true;                //Checkt op of array leeg is
        for (int i = 0; i < wave.Length; i++)
        {
          if (wave[i] != null)
          {
            ArrayIsNull = false;
            Debug.Log(ArrayIsNull);
          }
          
        }
        return ArrayIsNull;
    }


    private void spawnWave(GameObject[] wave)    //wave i verwijst naar het object dat je in de inspector hebt ingesleept
    {
      for (int i = 0; i < wave.Length; i++)
      {
        wave[i] = Instantiate(wave[i], transform.position + transform.right * (i * 6), transform.rotation) as GameObject;
      }

    }

    // Use this for initialization
    void Start()
    {
      spawnWave(wave1);
    
    }

    // Update is called once per frame
    void Update()
    {

      if (isWaveEmpty(wave1) && wave2CanStart)
      {
        spawnWave(wave2);
          wave2CanStart = false;
      }

      else if (isWaveEmpty(wave2) && wave3CanStart)
      {
        spawnWave(wave3);
        wave3CanStart = false;
      }

      else if (isWaveEmpty(wave3) && wave4CanStart)
      {
        spawnWave(wave4);
        wave4CanStart = false;
      }

      else if (isWaveEmpty(wave4) && wave5CanStart)
      {
        spawnWave(wave5);
        wave5CanStart = false;
      }

      else if (isWaveEmpty(wave5))
      {
        Debug.Log("you win");
        wave5CanStart = false;
      }

      else 
      {
        Debug.Log("wave not empty");
      }

    }

    

    




















    //for (int i = 0; i < waveSpider.Length; i++)
    //{

    //}
    //for (int i = 0; i < waveSuperSpider.Length; i++)
    //{

    //}
    //for (int i = 0; i < waveBoss.Length; i++)
    //{

    //}

    //  bool allNull = true;
    //for (int i = 0; i < wave1.Length; i++)
    //{
    //  if (wave1[i] != null)
    //  {
    //    allNull = false;
    //    //spiders[i] = Instantiate(spider, transform.position, transform.rotation) as GameObject;
    //  }
    //}
    //if (allNull)
    //{ 
    //wave2
      //foreach (GameObject spin in spiders)
      //{
      //  if (spin == null)
      //  {
      //    spin = Instantiate(spider, transform.position, transform.rotation) as GameObject;
      //  }
      //}

      //foreach (GameObject initSpider in spiders)
      //{
          
          
      
      //    if (initSpider == null)
      //    {
      //        for (int i = 0; i < spiders.Length; i++)
      //        {
                  
      //        }
      //    }
      //}


        ////spawns enemies in waves, once all dead, spawns more
        //      private bool waveSpawner = false;
        //      
        //      public int totalEnemy = 10;
	    //      private int numEnemy = 0;
        //      private int spawnedEnemy = 0;
        //
        //      public int totalWaves = 5;      //max aantal waves
	    //      private int numWaves = 0;       //begin aantal waves
        //
        //        if(numWaves < totalWaves)
        //        {
        //            if (waveSpawner)
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
        //          //code voor spawnEnemy
        //          //verhoog het totale aantal enemies die gaan spawnen en die gespawned zijn 
        //          numEnemy++;
        //          spawnedEnemy++;
        //      }
        //
        //    


}

