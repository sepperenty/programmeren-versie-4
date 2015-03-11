using UnityEngine;
using System.Collections;

public class Bullet : Projectile
{
  public float shootDistance = 500f;
  private float damage = 0.1f;
  private const string HIT_BY_BULLET = "HitByBullet";

  protected override void move()
  {
    RaycastHit hit;
    Ray shootingRay = new Ray(transform.position, transform.forward * shootDistance);
    Debug.DrawRay(transform.position, transform.forward * shootDistance);
    //GameObject shootFireclone = Instantiate(shootFire, transform.position, transform.rotation) as GameObject;

    //Destroy(shootFireclone, 0.5f);

    if (Physics.Raycast(shootingRay, out hit))
    {
      if (hit.collider.tag == DestroyedCityConstants.SPIDER_TAG)

      {
        hit.collider.SendMessage(DestroyedCityConstants.HIT_BY_BULLET, damage);
        Debug.Log("hit");
      }
    }
  }
}
