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

    public bool IsWaveEmpty( GameObject[]wave) 
    {
        bool ArrayIsNull = true; //Checkt op of array leeg is
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

    //wave i verwijst naar het object dat je in de inspector hebt ingesleept
    private void SpawnWave(GameObject[] wave)
    {
      for (int i = 0; i < wave.Length; i++)
      {
        wave[i] = Instantiate(wave[i], transform.position + transform.right * (i * 6), transform.rotation) as GameObject;
      }
    }

    // Use this for initialization
    void Start()
    {
      SpawnWave(wave1);
    
    }

    // Update is called once per frame
    void Update()
    {

      if (IsWaveEmpty(wave1) && wave2CanStart)
      {
        SpawnWave(wave2);
          wave2CanStart = false;
      }

      else if (IsWaveEmpty(wave2) && wave3CanStart)
      {
        SpawnWave(wave3);
        wave3CanStart = false;
      }

      else if (IsWaveEmpty(wave3) && wave4CanStart)
      {
        SpawnWave(wave4);
        wave4CanStart = false;
      }

      else if (IsWaveEmpty(wave4) && wave5CanStart)
      {
        SpawnWave(wave5);
        wave5CanStart = false;
      }

      else if (IsWaveEmpty(wave5))
      {
        Debug.Log("you win");
        wave5CanStart = false;
      }

      else 
      {
        Debug.Log("wave not empty");
      }

    }
}

