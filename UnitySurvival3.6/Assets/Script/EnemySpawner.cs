using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{

    public GameObject spider;
    private GameObject[] wave;
    private int waveLength = 5;
    private int waveInterval = 2;

   public GameObject[] waveSpider;
    private GameObject[] waveSuperSpider;
    private GameObject[] waveBoss;

    public int amountOfSpiders = 1;

    public void createNewWave(GameObject[]wave, int waveLength)
    {
            wave = new GameObject[waveLength];
            for (int i = 0; i < wave.Length; i++)
            {
                wave[i] = Instantiate(spider, transform.position + transform.right * (i * 6), transform.rotation) as GameObject; //6 omdat deze dan naast elkaar komen
            }
    }
    public bool isWaveEmpty( GameObject[]wave) 
    {
        bool ArrayIsNull = true;
        for (int i = 0; i < wave.Length; i++)
        {
            if (wave[i] != null)
            {
                ArrayIsNull = false;
                Debug.Log("Empty");
            }
        }
        return ArrayIsNull;
        
        
    }
    // Use this for initialization
    void Start()
    {
        createNewWave(wave, waveLength);

    }

    // Update is called once per frame
    void Update()
    {
        if (isWaveEmpty(wave))
	    {
		    waveLength += waveInterval;
            createNewWave(wave, waveLength);
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

