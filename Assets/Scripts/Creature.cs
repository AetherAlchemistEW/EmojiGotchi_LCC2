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

    //Poop Prefab
    public GameObject poopPrefab;

    //stat timers
    public float tirednessTimer, hungerTimer, poopTimer, sickTimer;
    public float tirednessTimerCap, hungerTimerCap, poopTimerCap, sickTimerCap;

    float hungerPercentage;

    void Start ()
    {
        tirednessTimer = tirednessTimerCap;
        hungerTimer = hungerTimerCap;
        poopTimer = poopTimerCap;
        sickTimer = sickTimerCap;
        StartCoroutine("HungerSystem");
    }

    // Update is called once per frame
    void Update ()
    {
        //Poop
        if (hungerPercentage > 0.5f)
        {
            poopTimer -= Time.smoothDeltaTime;
        }
        
        if(poopTimer / poopTimerCap <= 0)
        {
            //Poop
            Poop();
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

    IEnumerator HungerSystem()
    {
        //Hunger
        hungerTimer -= Time.smoothDeltaTime;
        hungerPercentage = hungerTimer / hungerTimerCap;
        //Debug.Log("HungerSystem");
        if (hungerPercentage < 0.75f)
        {
            //Debug.Log("Find Food");
            //Look for food
            GameObject food = GameObject.FindGameObjectWithTag("Food");
            //if food 
            while (food != null)
            {
                //Debug.Log("Yay Food!");
                //move to the food
                if (Vector2.Distance(transform.position, food.transform.position) <0.5f)
                {
                    //eat the food
                    hungerTimer = hungerTimerCap;
                    Destroy(food);
                    //Debug.Log("NomNomNom");
                }
                yield return null;
            }  
        }
        if (hungerPercentage < 0.2f)
        {
            //Get Sick
        }
        yield return null;
        StartCoroutine("HungerSystem");
    }

    //Poop
    void Poop()
    {
        //Spawn Poop
        Instantiate(poopPrefab, transform.position, Quaternion.identity);
        //Increase Poop Number
        poopNumber++;
    }

    //Sleep
        //Set asleep, while asleep 
        //run timer down until <0
        //Set not asleep

    //Eat
        //Find food, if food move to food, once at food eat

    //Die
        //Spawn Headstone
        //Destroy
}
