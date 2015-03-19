using UnityEngine;
using System.Collections;

public class SpiderBomb : MonoBehaviour
{
    private float damage = 0.7f;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == DestroyedCityConstants.PLAYER)
        {
            other.collider.SendMessage(DestroyedCityConstants.HIT_BY_SPIDER, damage);
        }
        Destroy(gameObject);
    }
}
