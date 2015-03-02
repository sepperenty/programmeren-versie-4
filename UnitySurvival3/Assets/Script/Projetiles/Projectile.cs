using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{

  
  protected float Damage;


  void Start()
  {

  }


  void Update()
  {

  }

  public virtual void move( )
  {
    
  }

  public virtual void makeExplosion(GameObject explosion, Collider other)
  {
    Destroy(gameObject);
    GameObject explosionClone;
    explosionClone = Instantiate(explosion, transform.position, transform.rotation) as GameObject;
    Destroy(explosionClone, 3f);
  }


}
