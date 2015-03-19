using UnityEngine;
using System.Collections;

//Abstracte classe om alle projectielen uit aan te maken.
//You can't create an instance of them, you have to subclass them
//Something that is more of a concept than a real thing
public abstract class Projectile : MonoBehaviour
{
    protected float fireSpeed = 1000f;
    protected float timeToLiveDestroy = 3f;
    protected GameObject endOfBarrel;
    //Methode stelt de beweging van het projectiel voor. Het wordt overschreven in de Bullet.
    protected virtual void Move()
    {
      
    }
    //Deze klasse wordt opgeroepen in de Mine en de Rocket klasse als het projectiel iets aanraakt.
    //Het object wordt verwijderd.
    //Er wordt een animatie van een explosie getoont op de plek waar de aanraking is.
    //Die explosie wordt ook verwijdert.
    public virtual void MakeExplosion(GameObject explosion, Collider other)
    {
        Destroy(gameObject);
        GameObject explosionClone;
        explosionClone = Instantiate(explosion, transform.position, transform.rotation) as GameObject;
        Destroy(explosionClone, timeToLiveDestroy);
    }


}
