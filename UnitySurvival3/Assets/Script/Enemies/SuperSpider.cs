using UnityEngine;
using System.Collections;

public class SuperSpider : Spider {

  public Rigidbody spiderBom;
  public Transform spiderShootPosition;
  protected float shootPower = 1000;

	// Use this for initialization
	void Start () {

    maxDistanceAttack = 20;
	
	}
	
void Update()
  {
    timerCheck();
    healthCheck();

  }

public override void Attack()
{
  transform.LookAt(player);
  animation.Play("Idle");
  Rigidbody spiderBomClone = Instantiate(spiderBom, spiderShootPosition.position, spiderShootPosition.rotation) as Rigidbody;
  spiderBomClone.AddForce(spiderShootPosition.transform.forward * shootPower);
}
 
}
