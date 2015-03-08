using UnityEngine;
using System.Collections;

public class Boss : SuperSpider {

    private float teleportTimer = 0f;
    private float canTeleport = 10f;
    private float canNotTelePort = 0f;
    private float teleportTimerInterval = 0.1f;

    private const int TELEPORT_LEFT = 1;
    private const int TELEPORT_RIGHT = 2;
    private const int TELEPORT_BACK = 3;
    private const int TELEPORT_FORWARD = 4;
    

    protected override void move()
    {
      if (isAlive)
      {
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
        //Vector3 position = player.transform.position;

        //float distance = Random.Range(10.0f, 30.0f);

        //Vector3 objPosition = position + player.transform.forward * distance;
        //RaycastHit hit;
        //Vector3 startHit = objPosition;
        //startHit.y += 200;
        //Physics.Raycast(startHit, Vector3.down, out hit);
        //objPosition.y = hit.point.y + 0.5f;
        //transform.position = objPosition;




        int randomNumber = Random.Range(1, 5);
       // Debug.Log(randomNumber);

        Vector3 position = player.transform.position;


        Vector3 spawnPosition = position + player.transform.forward * maxDistanceAttack; ;

        if (randomNumber == TELEPORT_BACK)
        { 
          spawnPosition = position + -player.transform.forward * maxDistanceAttack;
        }

        else if (randomNumber == TELEPORT_FORWARD)
        {
          spawnPosition = position + player.transform.forward * maxDistanceAttack;
        }

        else if (randomNumber == TELEPORT_RIGHT)
        {
          spawnPosition = position + player.transform.right * maxDistanceAttack;
        }

        else if (randomNumber == TELEPORT_LEFT)
        {
          spawnPosition = position + -player.transform.right * maxDistanceAttack;
        }

        RaycastHit hit;
        Vector3 rayStart = spawnPosition;
        rayStart.y += 200;
        Physics.Raycast(rayStart, Vector3.down, out hit);
        spawnPosition.y = hit.point.y + 2f;
        transform.position = spawnPosition;
    }


    

   
}
