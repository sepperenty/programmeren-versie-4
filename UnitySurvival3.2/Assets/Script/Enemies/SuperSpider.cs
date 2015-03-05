using UnityEngine;
using System.Collections;

public class SuperSpider : Spider
{

  public Rigidbody spiderBom;
  public Transform spiderShootPosition;
  protected float shootPower = 1000;

  // Use this for initialization
  void Start()
  {

    maxDistanceAttack = 20;

  }

  protected override void Attack()
  {
    transform.LookAt(player.transform.position);
    animation.Play("Idle");
    Rigidbody spiderBomClone = Instantiate(spiderBom, spiderShootPosition.position, spiderShootPosition.rotation) as Rigidbody;
    spiderBomClone.AddForce(spiderShootPosition.transform.forward * shootPower);
  }

}
