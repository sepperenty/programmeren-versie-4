using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour
{
  public int amountOfBullets = 500;
  public int amountOfRockets = 10;

  public GameObject bazooka;
  public GameObject machineGun;
  public GameObject mineHands;

  private bool machineGunSelected = true;
  private bool bazookaSelected = false;
  private bool mineSelected = false;

  private int rocketTimer;
  public const int ROCKET_CAN_BE_SHOT = 50;
  private const  int ROCKET_CAN_NOT_BE_SHOT = 0;

  private int mineTimer;
  public int mineCanBeThrown = 20;
  private int mineCanNoTBeThrown = 0;

  public GameObject endOfBarrelGun;
  public Transform endOfBarrelBazooka;


  public Rigidbody rocket;
  public Rigidbody mine;

  public GameObject rocketBal;                                                                 //Manier om variable uit sript aan ander GameObjet te halen   
  private Rocket rocketBalScript;                                                              // ""

  // Use this for initialization
  void Start()
  {
    machineGun.SetActive(true);

    bazooka.SetActive(false);
  }

  /**
   * 
   * */
  // Update is called once per frame
  void Update()
  {
    WeaponCheck();                                                                                                                   //Checkt welk wapen er moet getoont worden.

    if (Input.GetKey(KeyCode.Mouse0) && machineGunSelected && amountOfBullets > 0)
    {
      ShootMachineGun();
    }

    if (Input.GetKey(KeyCode.Mouse0) && bazookaSelected && rocketTimer == ROCKET_CAN_BE_SHOT && amountOfRockets > 0)                                           //als de linkerMuis toets wordt ingedrukt, de bazooka is geselecteerd als wapen en de rocketTimer hoog genoeg is
    {
      ShootRocket();
    }

    if (Input.GetKey(KeyCode.Mouse0) && mineSelected && mineTimer == mineCanBeThrown)
    {
      ThrowMine();
    }

    if (mineTimer < mineCanBeThrown)
    {
      mineTimer++;
    }

    if (rocketTimer < ROCKET_CAN_BE_SHOT)                                                                                               //als de timer kleiner is dan de toegelate grootte
    {
      rocketTimer++;                                                                                                                  //Moet hij worden opgetelt
    }

  }

  private void ThrowMine()
  {
    mineTimer = mineCanNoTBeThrown;
    Rigidbody mineClone = Instantiate(mine, endOfBarrelBazooka.transform.position, endOfBarrelBazooka.transform.rotation) as Rigidbody;
  }

  private void ShootRocket()
  {
    rocketTimer = ROCKET_CAN_NOT_BE_SHOT;                                                                                             //rocketTimer wordt terug op nul gezet
    Rigidbody rocketCLone;                                                                                                         // De variabele om een Clone van Roket in te steken
    rocketCLone = Instantiate(rocket, endOfBarrelBazooka.transform.position, endOfBarrelBazooka.transform.rotation) as Rigidbody; //een clone van rocket wordt aangemaakt
    rocketBalScript = rocketBal.GetComponent<Rocket>();                                                                             // er wordt gerefereert naar het juiste script om de snelheid van de rocket uit te halen   
    rocketCLone.AddForce(endOfBarrelBazooka.transform.forward * rocketBalScript.MoveSpeed);
    Debug.Log(rocketBalScript.MoveSpeed);
    amountOfRockets--;
  }

  private void ShootMachineGun()
  {
    endOfBarrelGun.SendMessage("move");                                                                                           //de Move methode van de klasse bullet wordt opgeroepen
    amountOfBullets--;
  }

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

  private void ActivateMachineGun()
  {
    machineGun.SetActive(true);
    bazooka.SetActive(false);
    machineGunSelected = true;
    bazookaSelected = false;
    mineSelected = false;
  }

  private void ActivateBazooka()
  {
    machineGun.SetActive(false);
    bazooka.SetActive(true);
    machineGunSelected = false;
    bazookaSelected = true;
    mineSelected = false;
  }

  private void ActivateMines()
  {
    machineGunSelected = false;
    bazookaSelected = false;
    mineSelected = true;
  }
}
