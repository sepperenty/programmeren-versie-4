using UnityEngine;
using System.Collections;

public class Mine : Projectile {

  public GameObject explosion;
  public GameObject explosionRadius;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

  void OnTriggerEnter(Collider other)
  {
    makeExplosion(explosion, other);
  }

  public override void makeExplosion(GameObject explosion,  Collider other)
  {
    if(other.collider.tag != "terrain" && other.collider.tag != "mine")
    {
      other.SendMessage("HitByRocket");
      base.makeExplosion(explosion, other);
      GameObject explosionRadiusClone = Instantiate(explosionRadius, transform.position, transform.rotation) as GameObject;
      Destroy(explosionRadiusClone, 1f);
    }
  }

 
  
}
