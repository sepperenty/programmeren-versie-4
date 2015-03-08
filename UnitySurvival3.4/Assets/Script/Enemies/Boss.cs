using UnityEngine;
using System.Collections;

public class Boss : SuperSpider {

    public Transform player;

    protected override void move()
    {
        base.move();
        
        float distance = Vector3.Distance(transform.position, player.transform.position);//DUBBELE CODE HELP!!
        if (distance <= maxDistanceAttack)
        {
            Teleport();           
        }
    }

    void Teleport()
    {
        Vector3 position = player.position;
        float distance = Random.Range(10.0f, 30.0f);
        Vector3 objPosition = position + player.forward * distance;
        RaycastHit hit;
        Vector3 startHit = objPosition;
        startHit.y += 200;
        Physics.Raycast(startHit, Vector3.down, out hit);
        objPosition.y = hit.point.y + 0.5f;
        transform.position = objPosition;
    }

    //First, we get the player position, 
    //second we get that random value to define where it should come up. 
    //We use the + forward of the player and multiply that by the distance, 
    //we get a point far in front. Now if the terrain is not flat, 
    //there is a chance the guy is below ground and will fall for eternity into limbo. 
    //So we use that position and make it 200 higher (this value may vary depending on your terrain),
    //then we raycast from that high position and see where the hit happens. 
    //We use the y value + 0.5f (half of your guy, may vary) 
    //and pass that final value to our position. 
}
