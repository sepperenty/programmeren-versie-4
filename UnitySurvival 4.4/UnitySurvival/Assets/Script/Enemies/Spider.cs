using UnityEngine;
using System.Collections;

public class Spider : MonoBehaviour
{
    protected GameObject player;
    protected float maxDistance = 50f;
    protected float maxDistanceAttack = 10f;
    public int moveSpeed = 10;
    protected float timer = 3f;
    public float turn = 500f;

    protected float attackTimer = 8;
    protected float canAttack = 10;
    protected float canNotAttack = 0;
    protected float timeInterval = 0.1f;
    protected float attackDamage = 0.5f;

    protected float distance;
    private float timeToLeveWhenDeath = 2f;

    protected bool isAlive = true;
    public float healthPoints = 10f;

    void Start()
    {

    }

    protected void Update()
    {
        TimerCheck();
        HealthCheck();
    }

    // TimerCheck zorgt ervoor dat de spin niet meteen naar de Player komt als hij spawnt. Hij wacht eerst enkele tellen.
    // Ook wordt er in de variabele player de locatie van de player gezet.
    //Als de timer 0 is wordt ook de afstand tussen de player en de Spiders vast gelegt in distance en wordt de move methode opgeroepen.
    private void TimerCheck()
    {
        player = GameObject.Find(DestroyedCityConstants.PLAYER);

        if (timer > 0f && isAlive)
        {
            timer -= Time.deltaTime;
            animation.Play(DestroyedCityConstants.IDLE_ANIMATION);
        }
        else
        {
            distance = Vector3.Distance(transform.position, player.transform.position);
            Move();
        }
    }

    //Deze methode wordt met enkele update opgeroepen om de health van de spider te checken. Als de healt 0 is dan wordt de Die() methode opgeroepen.
    private void HealthCheck()
    {
        if (healthPoints <= 0)
        {
            Die();
        }
    }

    //De move methode wordt opgeroepen in TimerCheck wanneer de Timer 0 is. De methode zorgt ervoor dat de spin begint te wandelen naar
    // de player als de distance tussen de 2 kleiner is dan de MaxDistance. Als de Distance tussen de 2 kleiner is dan de maxDistanceAttack dan wordt de AttackTimer 
    //methode opgeroepen waardoor de spin zal aanvallen.
    // Als de distance te groot is wordt de Idle animation opgeroepen van de spin en stopt ze met wandelen.
    protected virtual void Move()
    {
        if (isAlive)
        {
            if (distance <= maxDistance && distance >= maxDistanceAttack)
            {
                WalkToPlayer();
            }

            else if (distance < maxDistanceAttack)
            {
                AttackTimer();
            }
            else
            {
                animation.Play(DestroyedCityConstants.IDLE_ANIMATION);
            }
        }
    }

    // De WalkToPlayer methode wordt opgeroepen wanneer de distance tussen de spin en de player kleiner is dan de MaxDistance.
    // De Walt Animatie van de spin wordt opgeroepen.
    //De Positie van de spin wordt verenigvuldigt met de moveSpeed waardoor de spin naar voren zal bewegen.
    //De spin kijkt naar de player.
    protected void WalkToPlayer()
    {
        animation.Play(DestroyedCityConstants.WALK_ANIMATION);
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
        transform.LookAt(player.transform.position);
    }

    //Deze methode wordt opgeroepen in de PlayerShoot klasse die vast hangt aan de Player. Dit is wanneer een kogel de spin raakt.
    // Er wordt een damage met meegegeven en die wordt afgetrokken van de healthPoints van de spin.
    public void HitByBullet(float bulletDamage)
    {
        healthPoints -= bulletDamage;
    }

    //Deze methode wordt opgeroepen in de PLayerShoot Klasse die vast hangt aan de Player. Deze wordt opgeroepen wanneer de spin wordt geraakt door een Rocket.
    //Hiernij wordt geen damage meegegeven want de spin zal direct sterven.
    public void HitByRocket()
    {
        healthPoints -= healthPoints;
    }

    // Deze methode wordt aangeroepen in de Klasse die vast hangt aan de ExplosionRadius. Deze wordt opgeroepen wanneer de spin wordt geraakt door een explosie.
    //De damage wordt meegegeven.
    protected void HitByExplosion(float explosionDamage)
    {
        healthPoints -= explosionDamage;
    }

    //De methode AttackTimer wordt opgeroepen in de Move Methode wanneer de spin dichter bij is dan MaxDistanceAttack.
    //Het werkt met een timer zodat de spin niet elke Update Zou aanvallen.
    //AttackTimer wordt opgeteld tot het hoog genoeg is en dan zal de AttackMethode worden aangeroepen.
    protected void AttackTimer()
    {
        if (attackTimer >= canAttack)
        {
            Attack();
            attackTimer = canNotAttack;
        }

        else if (attackTimer < canAttack)
        {
            attackTimer += timeInterval;
            transform.LookAt(player.transform.position);
        }
    }

    // De attack methode zal worden aangeroepen in de methode AttackTimer. wanneer de variabele AttackTimer hoog genoeg is.
    //De spin moet naar de Player kijken. De Attack animatie van de spin wordt aangeroepen.
    //Er wordt via de SendMessage methode de HitBySpider methode opgeroepen van de Player.
    protected virtual void Attack()
    {
        transform.LookAt(player.transform.position);
        animation.Play(DestroyedCityConstants.ATTACK_ANIMATION);
        Debug.Log(DestroyedCityConstants.ATTACK_ANIMATION);
        player.SendMessage(DestroyedCityConstants.HIT_BY_SPIDER, attackDamage);
    }


    // Deze methode wordt opegeroepen in decimal HealthCheck methode wanneer de healthPoints van de Spin 0 zijn.
    // De isAlive Boolean wordt op false gezet om ervoor te zorgen dat de animaties van de spin niet tegelijk worden opgeroepen.
    // De die aniamatie wordt opgeroepen en de spin wordt verwijderd na een paar tellen.
    protected virtual void Die()
    {
        isAlive = false;

        if (!isAlive)
        {
            animation.Play(DestroyedCityConstants.DEATH_ANIMATION);
            Destroy(gameObject, timeToLeveWhenDeath);
        }
    }
}





