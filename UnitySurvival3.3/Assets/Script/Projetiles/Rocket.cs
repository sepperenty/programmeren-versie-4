using UnityEngine;
using System.Collections;

public class Rocket : Projectile
{

  //public GameObject rocketExplosion;
  private float moveSpeed = 1500f;
  public GameObject explosion;
  public GameObject explosionRadius;
  


  public float MoveSpeed
  {
    get { return moveSpeed; }
  }
  
  void OnTriggerEnter(Collider other)
  {
    makeExplosion(explosion, other);
  }

  public override void makeExplosion(GameObject explosion, Collider other)
  {
    base.makeExplosion(explosion, other);
    GameObject explosionRadiusClone = Instantiate(explosionRadius, transform.position, transform.rotation) as GameObject;
    Destroy(explosionRadiusClone, 1f);
    if (other.collider.tag == DestroyedCityConstants.SPIDER_TAG)
    {
      other.collider.SendMessage(DestroyedCityConstants.HIT_BY_ROCKET);
    }
  }
}
