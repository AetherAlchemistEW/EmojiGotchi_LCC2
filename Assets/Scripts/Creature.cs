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
    public float hygiene = 100;
    //Tiredness
    public float tiredness;
    //IsSick
    public bool isSick;
    //IsAwake
    public bool isAwake;

    //stat timers
    public float tirednessTimer, hungerTimer, poopTimer, sickTimer;
    public float tirednessTimerCap, hungerTimerCap, poopTimerCap, sickTimerCap;

    void Start ()
    {
        tirednessTimer = tirednessTimerCap;
        hungerTimer = hungerTimerCap;
        poopTimer = poopTimerCap;
        sickTimer = sickTimerCap;
    }

    // Update is called once per frame
    void Update ()
    {
        //Hunger
        hungerTimer -= Time.smoothDeltaTime;
        float hungerPercentage = hungerTimer / hungerTimerCap;
        if(hungerPercentage < 0.75f)
        {
            //Eat
        }
        if(hungerPercentage < 0.2f)
        {
            //Get Sick
        }

        //Poop
        if (hungerPercentage > 0.5f)
        {
            poopTimer -= Time.smoothDeltaTime;
        }
        
        if(poopTimer / poopTimerCap <= 0)
        {
            //Poop
            //Reset Timer
            poopTimer = poopTimerCap;
        }

        //Tired
        float tirednessPercentage = tirednessTimer / tirednessTimerCap;

        if (isAwake)
        {
            tirednessTimer -= Time.smoothDeltaTime;
            if (tirednessPercentage <= 0)
            {
                //< 0, Sleep
                isAwake = false;
            }
        }
        else
        {
            tirednessTimer += Time.smoothDeltaTime;
            if (tirednessPercentage >= 100)
            {
                //< 0, Sleep
                isAwake = true;
            }
        }

        //Sick
        hygiene -= poopNumber * age;
        if(hygiene/100 < 0.2f)
        {
            //get sick
            isSick = true;
        }
        //IsSick?
        if (isSick)
        {
            sickTimer -= Time.smoothDeltaTime;
            if(sickTimer <= 0)
            {
                //Spawn gravestone
                Destroy(gameObject);
            }
        }
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
