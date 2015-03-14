using UnityEngine;
using System.Collections;

public class ExplosionRadius : MonoBehaviour
{
    public float damage = 5;

    // Use this for initialization
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {


    }

    void OnTriggerEnter(Collider other)
    {
        explosion(other);
    }

    void explosion(Collider other)
    {
        if (other.tag == "spider")
        {
            other.SendMessage("HitByExplosion", damage);
        }
    }
}
