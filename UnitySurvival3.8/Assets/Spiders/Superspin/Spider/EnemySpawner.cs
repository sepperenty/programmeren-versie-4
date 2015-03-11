//using UnityEngine;
//using System.Collections;

//public class EnemySpawner : MonoBehaviour
//{

//    public Rigidbody spiderRigidbody;
//    public Transform playerTransform;
//    Spider spider1;

//    public float timer = 3;         //Timer count (seconden)


//    // Use this for initialization
//    void Start()
//    {
//      // // Spawn();
//      //spider1 = new Spider(100, 20, spiderRigidbody, playerTransform);
//      //spider1.SpiderClassRigidbody = (Rigidbody)Instantiate(spiderRigidbody, transform.position, transform.rotation);
//    }

//    // Update is called once per frame
//    void Update()
//    {
//      //Spawn();
//        //if (timer >= 0)
//        //{
//        //    timer -= Time.deltaTime;    //Timer die af telt tot dat spin start (eerst landen)
//        //    Debug.Log(timer);
//        //}

//        spider1.Move();
//    }

//    public void Spawn()
//    {
//        //Spider spiderTest = new Spider(100, 10, spiderRigidbody, playerTransform);
//        //spiderTest.SpiderClassRigidbody = Instantiate(spiderRigidbody, transform.position, transform.rotation) as Rigidbody;


     

//        if (timer <= 0)
//        {
           
//            animation.Play("walk");
//        }
//        //else
//        //{
//        //    animation.Play("Idle");
//        //}
//    }
//}
