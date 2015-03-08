//using UnityEngine;
//using System.Collections;

//public class SpiderTest : MonoBehaviour
//{
//    public Transform player;
//    public string building = "wrak_budova";
//    public float maxDistance;
//    public float maxDistanceAttack;
//    public int moveSpeed = 10;      //Speed of moving spider
//    public float timer = 3;         //Timer count (seconden)
//    public float turn = 500;

//    public float healthPoints = 10; //Spider HP

//  // Use this for initialization
//  void Start () {
//        //building = GameObject.FindWithTag("wrak_budova").gameObject;    //Building
//  }
	
//  // Update is called once per frame
//  void Update () {
//        if (timer >= 0)
//        {
//            timer -= Time.deltaTime;    //Timer die af telt tot dat spin start (eerst landen)
//        }

//        Move();                         //Methode move die zal worden overschreven
//  }

//    public void Move()
//    {
//        if (timer <= 0)
//        {
//            animation.Play("Idle");
//            float distance = Vector3.Distance(transform.position, player.transform.position);   //variabele die de afstand zal bekijken tussen Spider en Player
//            Debug.Log(distance);

//            //transform.position += transform.forward * moveSpeed * Time.deltaTime;   //Vooruit wandelen
            
//            //animation.Play("Idle"); GROTE FOUT NIET MEER OPZETTEN

//            //--->WERKT NIET HELP???
//            //RaycastHit hitWall;
//            //if (Physics.Raycast(transform.position, Vector3.forward, out hitWall, 20)) //20 is de lengte van de ray
//            //{
//            //    string objectHit = hitWall.transform.name;
//            //    Debug.Log(objectHit);
//            //    if (objectHit == building)
//            //    {
//            //        transform.Rotate(0, Time.deltaTime * 20, 0);    //draai tot building uit zicht is
//            //    }
//            //}
//            //--->WERKT NIET HELP???
            


//            if (distance <= maxDistance && distance >= maxDistanceAttack) //Als de speler en spider dicht bij elkaar komen
//            {
//                animation.Play("Walk");
//                transform.position += transform.forward * moveSpeed * Time.deltaTime;   //Vooruit wandelen
//                transform.LookAt(player);   //Kijk naar de player (= volgen)

//                //WEET NOG NIET HOE HET WERKT
//                //var rotation = Quaternion.LookRotation(player.position - transform.position);
//                //transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * turn);
//            }
//            if (distance <= maxDistanceAttack)
//            {

//                Attack();
//            }

//        }
//        else
//        {
//            animation.Play("Idle");
//        }

//    }

//    public void Attack()
//    {
//        animation.Play("Attack");
//        Debug.Log("Attack");
//    }
//}
