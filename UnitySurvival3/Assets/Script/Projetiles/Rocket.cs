using UnityEngine;
using System.Collections;

public class Rocket : Projectile
{

  //public GameObject rocketExplosion;
  public float moveSpeed;
  public GameObject explosion;
  public GameObject explosionRadius;

  public float MoveSpeed
  {
    get { return moveSpeed; }
  }
  
  private 

  void Start()
  {

  }


  void Update()
  {
   
  }

  void OnTriggerEnter(Collider other)
  {
    makeExplosion(explosion, other);
  }

  public override void makeExplosion(GameObject explosion, Collider other)
  {
    base.makeExplosion(explosion, other);
    GameObject explosionRadiusClone = Instantiate(explosionRadius, transform.position, transform.rotation) as GameObject;
    Destroy(explosionRadiusClone, 2f);
    if (other.collider.tag == "spider")
    {
      other.collider.SendMessage("HitByRocket");
    }
  }
}
