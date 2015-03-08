using UnityEngine;
using System.Collections;

public class Mine : Projectile {

  public GameObject explosion;
  public GameObject explosionRadius;


  void OnTriggerEnter(Collider other)
  {
    makeExplosion(explosion, other);
  }

  public override void makeExplosion(GameObject explosion,  Collider other)
  {
    
    
      if (other.collider.tag == DestroyedCityConstants.SPIDER_TAG)
      {
        base.makeExplosion(explosion, other);
        HitSpiderByRocket(other);
        GameObject explosionRadiusClone = Instantiate(explosionRadius, transform.position, transform.rotation) as GameObject;
        Destroy(explosionRadiusClone, 1f);
      }
     
  }

  private void HitSpiderByRocket(Collider other)
  {
    other.SendMessage(DestroyedCityConstants.HIT_BY_ROCKET);
  }

 
  
}
