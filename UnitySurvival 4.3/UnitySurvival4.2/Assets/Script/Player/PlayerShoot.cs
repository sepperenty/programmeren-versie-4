using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour
{
    public int amountOfBullets = 500;
    public int amountOfRockets = 10;
    public int amountOfMines = 10;

    public GameObject bazooka;
    public GameObject machineGun;
    public GameObject mineHands;
    public GameObject bulletFire;

    private bool machineGunSelected = true;
    private bool bazookaSelected = false;
    private bool mineSelected = false;

    private int rocketTimer;
    public const int ROCKET_CAN_BE_SHOT = 50;
    private const int ROCKET_CAN_NOT_BE_SHOT = 0;

    private int mineTimer;
    public int mineCanBeThrown = 20;
    private int mineCanNoTBeThrown = 0;

    public GameObject endOfBarrelGun;
    public Transform endOfBarrelBazooka;

    public Rigidbody rocket;
    public Rigidbody mine;

    public GameObject rocketBal;
    private Rocket rocketBalScript;

    // Use this for initialization
    void Start()
    {
        machineGun.SetActive(true);

        bazooka.SetActive(false);
    }

    // Update is called once per frame
    //Er wordt gecheckt welke toets er wordt ingedrukt om te kijken welk wapen er gevuurt moet worden. 
    //Er wordt ook gecheckt of er genoeg kogels zitten in elk wapen.
    void Update()
    {
        WeaponCheck();

        if (Input.GetKey(KeyCode.Mouse0) && machineGunSelected && amountOfBullets > 0)
        {
            ShootMachineGun();
        }
        else
        {
            bulletFire.SetActive(false);
        }

        if (Input.GetKey(KeyCode.Mouse0) && bazookaSelected && rocketTimer == ROCKET_CAN_BE_SHOT && amountOfRockets > 0)
        {
            ShootRocket();
        }

        if (Input.GetKey(KeyCode.Mouse0) && mineSelected && mineTimer == mineCanBeThrown && amountOfMines > 0)
        {
            ThrowMine();
        }

        if (mineTimer < mineCanBeThrown)
        {
            mineTimer++;
        }

        if (rocketTimer < ROCKET_CAN_BE_SHOT)
        {
            rocketTimer++;
        }

    }

    // ThrowMin wordt opgeroepen in de Update methode als er een bepaalde toets wordt ingedrukt.
    // De mineTimer wordt gebruikt zodat men maar om de zoveel tellen een mijn kan gooien.
    // Er wordt een Clone gemaakt van de Mine.

    private void ThrowMine()
    {
        mineTimer = mineCanNoTBeThrown;
        Rigidbody mineClone = Instantiate(mine, endOfBarrelBazooka.transform.position, endOfBarrelBazooka.transform.rotation) as Rigidbody;
        amountOfMines--;
    }

    // Deze methode wordt opgeroepen in de Update methode als er een bepaalde toets wordt ingedrukt.
    // De RocketTimer wordt gebruikt zodat er maar om de zoveel tellen een rocket kan worden afgevuurt.
    //Er wordt een clone gemaakt en afgevuurt.
    //Met de GeComponent methode wordt er naar het script aan de rocket gerefereerd waar men dan de MoveSpeed uit kan halen.
    //Ook word er van de amount of rockets afgetrokken.
    private void ShootRocket()
    {
        rocketTimer = ROCKET_CAN_NOT_BE_SHOT;
        Rigidbody rocketCLone;
        rocketCLone = Instantiate(rocket, endOfBarrelBazooka.transform.position, endOfBarrelBazooka.transform.rotation) as Rigidbody;
        rocketBalScript = rocketBal.GetComponent<Rocket>();
        rocketCLone.AddForce(endOfBarrelBazooka.transform.forward * rocketBalScript.MoveSpeed);
        Debug.Log(rocketBalScript.MoveSpeed);
        amountOfRockets--;
    }
    //Deze methode wordt opgeroepen in de Update methode als er op een bepaalde toets wordt gedrukt.
    //Er wordt gerefereert naar het BulletScript.
    //Er wordt ook een laser active gezet zodat men kogels ziet.
    private void ShootMachineGun()
    {
        endOfBarrelGun.SendMessage("move");
        amountOfBullets--;
        bulletFire.SetActive(true);
    }

    //Hier wordt er gecheckt welk wapen er active moet worden gezet zodat met het wapen ziet.

    public void WeaponCheck()
    {
        if (Input.GetKey(KeyCode.F1))
        {
            ActivateMachineGun();
        }

        else if (Input.GetKey(KeyCode.F2))
        {
            ActivateBazooka();
        }

        else if (Input.GetKey(KeyCode.F3))
        {
            ActivateMines();
        }

    }
    // Zet de machine gun active zodat je het wapen ziet.
    private void ActivateMachineGun()
    {
        machineGun.SetActive(true);
        bazooka.SetActive(false);
        machineGunSelected = true;
        bazookaSelected = false;
        mineSelected = false;
    }
    //Zet de bazooka active zodat je de bazooka ziet.
    private void ActivateBazooka()
    {
        machineGun.SetActive(false);
        bazooka.SetActive(true);
        machineGunSelected = false;
        bazookaSelected = true;
        mineSelected = false;
    }
    //Zet alles op non active zodat je geen wapen ziet.
    private void ActivateMines()
    {
        machineGunSelected = false;
        bazookaSelected = false;
        mineSelected = true;
        bazooka.SetActive(false);
        machineGun.SetActive(false);
    }
}
