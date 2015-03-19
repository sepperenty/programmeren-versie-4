﻿using UnityEngine;
using System.Collections;

public class Bullet : Projectile
{
    public float shootDistance = 500f;
    private float damage = 0.1f;
    private const string HIT_BY_BULLET = "HitByBullet";

    //De methode move van de SuperKlasse wordt overschreven.
    // Er wordt een rayCast gezet in de richting van waar er gemikt wordt.
    // ALs deze ray een spin raakt wordt er een methode in deze spin opgeroepen: hitbybullet.
    //De damage wordt hier ook aan meegegeven.
    protected override void Move()
    {
        RaycastHit hit;
        Ray shootingRay = new Ray(transform.position, transform.forward * shootDistance);
        Debug.DrawRay(transform.position, transform.forward * shootDistance);

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
