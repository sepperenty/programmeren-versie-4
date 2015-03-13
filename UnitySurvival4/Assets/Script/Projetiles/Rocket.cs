using UnityEngine;
using System.Collections;

public class Rocket : Projectile
{

  //public GameObject rocketExplosion;
  public float moveSpeed = 1800f;
  public GameObject explosion;
  public GameObject explosionRadius;
  public float timeToLive = 0.5f;
  void Start()
  {
    
  }
  

  //Hierin wordt de kracht van de Rocket gezet. In het script player shoot vraagt men deze waarde.
  public float MoveSpeed
  {
    get { return moveSpeed; }
  }

  //Methode wordt opgeroepen wanneer de rocket iets aanraakt.
  
  void OnTriggerEnter(Collider other)
  {
    makeExplosion(explosion, other);
  }
  
  //Er wordt gerefereert naar de basisKlasse om de make explosion op te roepen.
   //Er wordt een nieuwe explosionRadius aangemaakt dat de grote van de explosie voorstelt.
  //Als er een spin wordt geraakt door de rocket wordt er een methode in opgeroepen HitByRocket.
  public override void makeExplosion(GameObject explosion, Collider other)
  {
    base.makeExplosion(explosion, other);
    GameObject explosionRadiusClone = Instantiate(explosionRadius, transform.position, transform.rotation) as GameObject;
    Destroy(explosionRadiusClone, timeToLive);

    if (other.collider.tag == DestroyedCityConstants.SPIDER_TAG)
    {
      other.collider.SendMessage(DestroyedCityConstants.HIT_BY_ROCKET);
    }
  }
}
