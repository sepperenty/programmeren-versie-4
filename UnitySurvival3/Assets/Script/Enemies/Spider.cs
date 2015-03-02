using UnityEngine;
using System.Collections;

public class Spider : MonoBehaviour
{

  public Transform player;                                                                  //Deeft de locatie van de player.
  public float maxDistance = 50f;                                                           //De afstand wanneer de spin naar de player gaat komen.
  public float maxDistanceAttack = 10f;                                                     //De afstand van de player naar de spin wanneer de spin gaat aanvallen.
  public int moveSpeed = 10;                                                                //Geeft de snelheid van de spin.
  protected float timer = 3f;                                                                  //de tijd wanneer de spinnen tot leven komen
  public float turn = 500f;

  protected float attackTimer = 0;
  protected float canAttack = 10;
  protected float canNotAttack = 0;
  protected float timeInterval = 0.1f;

  private bool isAlive = true;                                                              //Is true wanneer de spin leeft


  public float healthPoints = 10f;                                                          //de totale health van de spin.    


  void Start()
  {
    Debug.Log("sript werkt");
  }

  void Update()
  {
    timerCheck();
    healthCheck();
  }

  public void timerCheck()
  {
    if (timer > 0f && isAlive)                                                              //Als de timer nog niet naar 0 is afgeteld en de spin leeft.
    {
      timer -= Time.deltaTime;                                                              //De tijd laten aftellen
      //Debug.Log(timer); 
      animation.Play("Idle");                                                               //Geeft de animatie dat de spin ademt en stil staat.
    }
    else
    {
      move();                                                                               //Roept de move methode op.
    }
  }

  public void healthCheck()
  {
    if (healthPoints <= 0)                                                                  //Checkt of de spin nog in leven is.
    {
      Die();                                                                                //Als de spin dood is roept het de Die() methode op.
    }
  }

  public virtual void move()                                                                //De move methode
  {
    if (isAlive)                                                                            //Als de spin leeft
    {
      float distance = Vector3.Distance(transform.position, player.position);               //De distance wordt berekent tussen de player en de spin. Dit wordt opgeslagen in de variabele "distance".
      //Debug.Log(distance);

      if (distance <= maxDistance && distance >= maxDistanceAttack)                         //Als de spin dichter bij is dan de afstand wanneer hij naar de player moet komen maar verder dan de afstand wanneer hij moet aanvallen.
      {
        animation.Play("Walk");                                                             //Roept de wandel animatie van de spin aan.
        transform.position += transform.forward * moveSpeed * Time.deltaTime;               //Laat de spin bewegen. Met de snelheid van de "moveSpeed".
        transform.LookAt(player);                                                           //Roept de methode op dat de spin doet kijken naar de PLayer.
      }

      else if (distance < maxDistanceAttack)                                                //Als de spin dicht genoeg is om te beginnen aanvallen dus kleiner dan "maxDistanceAttack1.
      {
        AttackTimer();                                                                          //Roept het de Attack methode op.
      }

      else
      {
        animation.Play("Idle");
      }

    }
  }

  public void HitByBullet(float bulletDamage)                                               //De methode die wordt opgeroepen als de Spin geraakt wordt door een Bullet.
  {
    healthPoints -= bulletDamage;                                                           //Van de Healthpoints wordt de damage van de Bullet afgetrokken.
    rigidbody.AddForce(-transform.forward * 50);                                            //Laat de spin een beetje naar achter bewegen als hij geraakt wordt door een kogel.
  }

  public void HitByRocket()                                                                 //De methode die wordt aangeroepen als de spin geraakt wordt door een Rocket.
  {
    healthPoints = 0f;                                                                      //Al het leven wordt ven da spin afgetrokken.
  }

  public void HitByExplosion(float explosionDamage)                                         //De methode die wordt aangeroepen als de spin door een explosie wordt geraakt.
  {
    healthPoints -= explosionDamage;                                                        //De damage van de explosie wordt afgetrokken van de health.
  }

  public void AttackTimer()
  {
    if (attackTimer >= canAttack)
    {
      Attack();
      attackTimer = canNotAttack;
    }

    else if (attackTimer < canAttack)
    {
      attackTimer += timeInterval;
      transform.LookAt(player);
     
      //animation.Play("Idle");
    }


  }

  public virtual void Attack()                                                              //De methode die wordt aangeroepen als de spin moet aanvallen.
  {
    attackTimer = canNotAttack;
    transform.LookAt(player);                                                               //Zorgt ervoor dat de spin naar de player blijft kijken.
    animation.Play("Attack");                                                               //Speelt de animatie af een spin die aanvalt.
    Debug.Log("attacking");                                                                 //Een test om te kijken of de methode wordt aangeroepen.

  }

  public virtual void Die()                                                                 //De methode die wordt aangeroepen als de spin door gaat.
  {
    isAlive = false;                                                                        //De bool isAlive wordt op false gezet.

    if (!isAlive)                                                                           //als de de bool isAlive false is
    {
      animation.Play("Death");                                                              //De animatie van een spin dat sterft wordt afgespeeld.
      Destroy(gameObject, 2f);                                                              //De gameObject van de spin wordt verwijdert na 2 seconden.
    }
  }

}





