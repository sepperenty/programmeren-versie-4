using UnityEngine;
using System.Collections;

/**
 * 
 * */
public class Spider : MonoBehaviour
{


    //public Transform player;                                                                //Deeft de locatie van de player.
    protected GameObject player;
    public float maxDistance = 50f;                                                           //De afstand wanneer de spin naar de player gaat komen.
    public float maxDistanceAttack = 10f;                                                     //De afstand van de player naar de spin wanneer de spin gaat aanvallen.
    public int moveSpeed = 10;                                                                //Geeft de snelheid van de spin.
    protected float timer = 3f;                                                               //de tijd wanneer de spinnen tot leven komen
    public float turn = 500f;

    protected float attackTimer = 8;                                                         //de timer die optelt en op 0 wordt gezet bij het aavallen. Wordt gecheckt in AttackTimer() om te kijken of de spin mag aanvallen.
    protected float canAttack = 10;                                                           //De float dat attackTimer moet berijken voor de spin kan aanvallen.
    protected float canNotAttack = 0;                                                         //Als attackTimer deze waarde heeft kan de spin niet aanvallen.
    protected float timeInterval = 0.1f;                                                      //Het interval waarmee attackTimer wordt opgeteld per Update als ze niet gelijk is aan canAttack of.

    private bool isAlive = true;                                                              //Is true wanneer de spin leeft


    public float healthPoints = 10f;                                                          //de totale health van de spin.    


    void Start()
    {
        Debug.Log("script werkt");                                                               //Test of het script werkt
    }

    protected void Update()
    {
        timerCheck();                                                                           //Methode TimerCheck wordt aangeroepen om de spin in beweging te zetten.
        healthCheck();                                                                          //De health van de spider wordt gecheckt. Als deze te laag is sterft de spin met behulp van de Die() methode
    }

    private void timerCheck()
    {
        player = GameObject.Find(DestroyedCityConstants.PLAYER);

        if (timer > 0f && isAlive)                                                              //Als de timer nog niet naar 0 is afgeteld en de spin leeft.
        {
            timer -= Time.deltaTime;                                                              //De tijd laten aftellen
            //Debug.Log(timer); 
            animation.Play(DestroyedCityConstants.IDLE_ANIMATION);                                                               //Geeft de animatie dat de spin ademt en stil staat.
        }
        else
        {
            move();                                                                               //Roept de move methode op.
        }
    }

    private void healthCheck()
    {
        if (healthPoints <= 0)                                                                  //Checkt of de spin nog in leven is.
        {
            Die();                                                                                //Als de spin dood is roept het de Die() methode op.
        }
    }

    protected virtual void move()                                                                //De move methode
    {
        if (isAlive)                                                                            //Als de spin leeft
        {
            float distance = Vector3.Distance(transform.position, player.transform.position);     //De distance wordt berekent tussen de player en de spin. Dit wordt opgeslagen in de variabele "distance".
            //Debug.Log(distance);

            if (distance <= maxDistance && distance >= maxDistanceAttack)                         //Als de spin dichter bij is dan de afstand wanneer hij naar de player moet komen maar verder dan de afstand wanneer hij moet aanvallen.
            {
                walkToPlayer();
            }

            else if (distance < maxDistanceAttack)                                                //Als de spin dicht genoeg is om te beginnen aanvallen dus kleiner dan "maxDistanceAttack1.
            {

                AttackTimer();                                                                      //Roept het de Attack methode op.
            }

            else
            {
                animation.Play(DestroyedCityConstants.IDLE_ANIMATION);                                                             //Als de spin te ver is van de Player om er naartoe te gaan, wordt de Idle Animatie gespeeld
            }

        }
    }

    private void walkToPlayer()
    {
        animation.Play(DestroyedCityConstants.WALK_ANIMATION);                                                             //Roept de wandel animatie van de spin aan.
        transform.position += transform.forward * moveSpeed * Time.deltaTime;               //Laat de spin bewegen. Met de snelheid van de "moveSpeed".
        transform.LookAt(player.transform.position);                                        //Roept de methode op dat de spin doet kijken naar de PLayer.
    }

    /**
     * klj;lk;,
     **/
    public void hitByBullet(float bulletDamage)                                               //De methode die wordt opgeroepen als de Spin geraakt wordt door een Bullet.
    {
        healthPoints -= bulletDamage;                                                           //Van de Healthpoints wordt de damage van de Bullet afgetrokken.
        //rigidbody.AddForce(-transform.forward * 50);                                          //Laat de spin een beetje naar achter bewegen als hij geraakt wordt door een kogel.
    }

    public void hitByRocket()                                                                 //De methode die wordt aangeroepen als de spin geraakt wordt door een Rocket.
    {
        //jkjlk
        healthPoints = 0f;                                                                      //Al het leven wordt ven da spin afgetrokken.
    }


    protected void hitByExplosion(float explosionDamage)                                         //De methode die wordt aangeroepen als de spin door een explosie wordt geraakt.
    {
        healthPoints -= explosionDamage;                                                        //De damage van de explosie wordt afgetrokken van de health.
    }

    protected void AttackTimer()                                                                 //De methode wordt aangeroepen wanneer de spin dicht bij de player is
    {
        if (attackTimer >= canAttack)                                                           //Als de attackTimer hoog genoeg is 
        {
            Attack();                                                                             //De methode Attack wordt aangeroepen
            attackTimer = canNotAttack;                                                           //attackTimer wordt op 0 gezet
        }

        else if (attackTimer < canAttack)                                                       //Als attackTimer niet hoog genoeg is
        {
            attackTimer += timeInterval;                                                          //attackTimer wordt opgeteld met het interval
            transform.LookAt(player.transform.position);                                          //Spin kijkt naar de player als hij aanvalt.

            //animation.Play("Idle");
        }


    }

    protected virtual void Attack()                                                              //De methode die wordt aangeroepen in AttackTimer() als hij moet aanvallen
    {
        attackTimer = canNotAttack;
        transform.LookAt(player.transform.position);                                            //Zorgt ervoor dat de spin naar de player blijft kijken.
        animation.Play(DestroyedCityConstants.ATTACK_ANIMATION);                                                               //Speelt de animatie af een spin die aanvalt.
        Debug.Log(DestroyedCityConstants.ATTACK_ANIMATION);                                                                 //Een test om te kijken of de methode wordt aangeroepen.

    }

    protected virtual void Die()                                                                 //De methode die wordt aangeroepen als de spin door gaat.
    {
        isAlive = false;                                                                        //De bool isAlive wordt op false gezet.

        if (!isAlive)                                                                           //als de de bool isAlive false is
        {
            animation.Play(DestroyedCityConstants.DEATH_ANIMATION);                                                              //De animatie van een spin dat sterft wordt afgespeeld.
            Destroy(gameObject, 2f);                                                              //De gameObject van de spin wordt verwijdert na 2 seconden.
        }
    }

}





