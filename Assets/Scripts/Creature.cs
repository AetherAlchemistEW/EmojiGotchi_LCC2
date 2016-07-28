using UnityEngine;
using System.Collections;

public class Creature : MonoBehaviour
{
    //VARIABLES
    //PoopNumber
    public int poopNumber;
    //Age
    public float age;
    //Hunger
    public float hunger;
    //Hygiene
    public float hygiene;
    //Tiredness
    public float tiredness;
    //IsSick
    public bool isSick;
    //IsAwake
    public bool isAwake;

    //stat timers
    public float tirednessTimer, hungerTimer, poopTimer, sickTimer;
	
	// Update is called once per frame
	void Update ()
    {
        //Hunger
        //Timer--
        //< 75 %, 
        //Eat
        //< 20 %, 
        //Get Sick
        //Poop
        //Hunger > 50 %
        //Timer--
        //< 0, 
        //Poop
        //Reset Timer
        //Tired
        //Awake?
        //Timer--
        //< 0, Sleep
        //Else
        //Timer++
        //> 100, Awake
        //Sick
        //Hygiene -= PoopNumber * Age
        //Hygiene < 20 %, Get Sick
        //IsSick?
        //Timer --
        //< 0, Die
    }

    //Poop
        //Spawn Poop
        //Increase Poop Number

    //Sleep
        //Set asleep, while asleep 
        //run timer down until <0
        //Set not asleep

    //Eat
        //Find food, if food move to food, once at food eat

    //GetSick
        //IsSick

    //Die
        //Spawn Headstone
        //Destroy
}
