using UnityEngine;
using System.Collections;

public class SuperSpider : Spider
{
    public Rigidbody spiderBom;
    public Transform spiderShootPosition;
    protected float shootPower = 1000;

    //De maxdistanceAttack wordt hoger gezet zodat de spin vanaf een verdere plaats al zal aavallen.
    void Start()
    {
        maxDistanceAttack = 20f;
    }

    //De Attack methode van de Spider wordt opvergeschreven. 
    //Deze methode wordt opgeroepen in de attackTimer Methode.
    // De Spin moet nog steeds naar de Player kijken.
    //De Idle animatie wordt opgeroepen en er wordt een spiderbom gevuurt naar de player.
    protected override void Attack()
    {
        transform.LookAt(player.transform.position);
        animation.Play(DestroyedCityConstants.IDLE_ANIMATION);
        Rigidbody spiderBomClone = Instantiate(spiderBom, spiderShootPosition.position, spiderShootPosition.rotation) as Rigidbody;
        spiderBomClone.AddForce(spiderShootPosition.transform.forward * shootPower);
    }
}
