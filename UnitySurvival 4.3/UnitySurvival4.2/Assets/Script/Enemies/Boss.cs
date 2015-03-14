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

    //De move methode wordt overgeschreven van de Klasse Spider.
    //Als de spin levent is en de afstand kleiner is dan maxDIstance dan zal de spin naar de PLayer beginnen wandelen. 
    //Maar vanaf de afstand gelijk is aan MaxDistance Attack zal de spin teleporteren van plek. Dit wordt gedaan door de TeleportTimer methode op te roepen.
    // Ook wordt de IdleAniamtie opgeroepen.
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
                AttackTimer();
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

    //Deze methode wordt opgeroepen in teleportTimer wanneer de spin kleiner of gelijk is aan MaxDistanceAttack.
    // Deze wordt random gedaan dus eerst moet er een random locatie worden afgesproken.
    //Dan wordt er een raycast naar beneden gericht om te kijken of de spin niet op een gebouw teleporteert of op een andere spin. 
    // Dit wordt dan met een while loop herhaalt tot de locatie deftig is.
    // Als de locatie deftig is wordt de spin een beetje boven die locatie gezet.
    void Teleport()
    {
        Vector3 randomPoint = Random.onUnitSphere * 5;
        RaycastHit hit;
        // Debug.Log(randomNumber);
        do
        {
            int randomNumber = Random.Range(1, 5);

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
            Vector3 rayStart = spawnPosition;
            rayStart.y += heightCheck;
            Physics.Raycast(rayStart, Vector3.down, out hit);
        }
        while (hit.collider.tag == DestroyedCityConstants.WRACK_TAG && hit.collider.tag == DestroyedCityConstants.SPIDER_TAG);
        spawnPosition.y = hit.point.y + spiderHeigt;
        transform.position = spawnPosition;
    }
}
