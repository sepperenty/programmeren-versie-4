﻿using UnityEngine;
using System.Collections;

public class Mine : Projectile
{
    public GameObject explosion;
    public GameObject explosionRadius;
    protected float timeToLiveExplosionRadius = 1f;

    void OnTriggerEnter(Collider other) //other = wat je hebt aangeraakt
    {
        makeExplosion(explosion, other);
    }

    public override void makeExplosion(GameObject explosion, Collider other)
    {
        if (other.collider.tag == DestroyedCityConstants.SPIDER_TAG)
        {
            base.makeExplosion(explosion, other); //eerst de superklasse aanroepen, dan de rest toevoegen
            HitSpiderByRocket(other);
            GameObject explosionRadiusClone = Instantiate(explosionRadius, transform.position, transform.rotation) as GameObject;
            Destroy(explosionRadiusClone, timeToLiveExplosionRadius);
        }
    }

    private void HitSpiderByRocket(Collider other)
    {
        other.SendMessage(DestroyedCityConstants.HIT_BY_ROCKET);
    }
}