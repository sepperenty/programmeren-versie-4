using UnityEngine;
using System.Collections;

public class Bullet : Projectile
{

  public float shootDistance = 500f;
  private float damage = 0.1f;
  public GameObject shootFire;

  // Use this for initialization
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {

  }

  public virtual void move()
  {
    RaycastHit hit;
    Ray shootingRay = new Ray(transform.position, transform.forward * shootDistance);
    Debug.DrawRay(transform.position, transform.forward * shootDistance);
    //GameObject shootFireclone = Instantiate(shootFire, transform.position, transform.rotation) as GameObject;

    //Destroy(shootFireclone, 0.5f);

    if (Physics.Raycast(shootingRay, out hit))
    {
      if (hit.collider.tag == "spider")
      {
        hit.collider.SendMessage("HitByBullet", damage);
        Debug.Log("hit");
      }
    }
  }
}
