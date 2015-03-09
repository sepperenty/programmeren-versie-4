using UnityEngine;
using System.Collections;

public class Boss : SuperSpider
{

    private float teleportTimer = 0f;
    private float canTeleport = 10f;
    private float canNotTelePort = 0f;
    private float teleportTimerInterval = 0.1f;

    private const int TELEPORT_LEFT = 1;
    private const int TELEPORT_RIGHT = 2;
    private const int TELEPORT_BACK = 3;
    private const int TELEPORT_FORWARD = 4;

    private int heightCheck = 200;
    private float spiderHeigt = 2.0f;

    private Vector3 playerPosition;
    private Vector3 spawnPosition;

    private RaycastHit hitClone;

    protected override void move()
    {
        if (isAlive)
        {
            playerPosition = player.transform.position;
            spawnPosition = playerPosition + player.transform.forward * maxDistanceAttack;
            if (distance <= maxDistance && distance > maxDistanceAttack)
            {
                walkToPlayer();
            }

            else if (distance <= maxDistanceAttack)
            {
                animation.Play(DestroyedCityConstants.IDLE_ANIMATION);

                if (teleportTimer >= canTeleport)
                {
                    teleportTimer = canNotAttack;
                    Teleport();
                }

                else if (teleportTimer < canTeleport)
                {
                    teleportTimer += teleportTimerInterval;
                }
            }
        }
    }

    void Teleport()
    {
        
        int randomNumber = Random.Range(1, 5);
        // Debug.Log(randomNumber);
        do
        {
            if (randomNumber == TELEPORT_BACK)
            {
                spawnPosition = playerPosition + -player.transform.forward * maxDistanceAttack;
            }

            else if (randomNumber == TELEPORT_FORWARD)
            {
                spawnPosition = playerPosition + player.transform.forward * maxDistanceAttack;
            }

            else if (randomNumber == TELEPORT_RIGHT)
            {
                spawnPosition = playerPosition + player.transform.right * maxDistanceAttack;
            }

            else if (randomNumber == TELEPORT_LEFT)
            {
                spawnPosition = playerPosition + -player.transform.right * maxDistanceAttack;
            }

        
            TeleportRaycast();
        }
        while (hitClone.collider.tag == DestroyedCityConstants.WRACK_TAG );
        transform.position = spawnPosition;
    }

    public void TeleportRaycast()
    {
        RaycastHit hit;
        Vector3 rayStart = spawnPosition;   //raystart is zelfde locatie, enkel hoger
        rayStart.y += heightCheck;
        Physics.Raycast(rayStart, Vector3.down, out hit);
        hitClone = returnHit(hit);
        spawnPosition.y = hit.point.y + spiderHeigt; //hit + 2m om de spider niet in de grond te laten spawnen
    }
    public RaycastHit returnHit(RaycastHit hit)
    {
        return hit;
    }




}
