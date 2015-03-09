using UnityEngine;
using System.Collections;
/**
 * Abstracte classe om alle projectielen uit aan te maken.
 * */
public abstract class Projectile : MonoBehaviour
{
    protected float timeToLiveDestroy = 3f;
    
    protected virtual void move()
    { }

    public virtual void makeExplosion(GameObject explosion, Collider other)
    {
        Destroy(gameObject);
        GameObject explosionClone;
        explosionClone = Instantiate(explosion, transform.position, transform.rotation) as GameObject;
        Destroy(explosionClone, timeToLiveDestroy);
    }


}
