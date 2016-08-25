using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    //VARIABLES
    //Creature Prefab
    public GameObject creaturePrefab;
    //Food Prefab
    public GameObject foodPrefab;

    //Creature Reference
    private GameObject creatureRef;

	// Update is called once per frame
	void Update ()
    {
	    //If Creature reference is null and input spawn creature and set to reference
        if(creatureRef == null && Input.GetKeyDown(KeyCode.Space))
        {
            Spawn();
        }

        //This method will clean up after our emojigotchi
        if(Input.GetKeyDown(KeyCode.C))
        {
            Clean();
        }

        //This method will feed our emojigotchi
        if (Input.GetKeyDown(KeyCode.F))
        {
            Feed();
        }
    }

    //Spawn
    void Spawn()
    {
        //Instantiate creature and set it to creature reference
        creatureRef = Instantiate(creaturePrefab);
    }

    //Clean
    void Clean()
    {
        //Remove all poop, reset creature poop number, reset creature hygiene
        foreach(GameObject currentPoop in GameObject.FindGameObjectsWithTag("Poop"))
        {
            Destroy(currentPoop);
        }
        creatureRef.GetComponent<Creature>().poopNumber = 0;
        creatureRef.GetComponent<Creature>().hygiene = 100;
    }

    //Feed
    void Feed()
    {
        //Spawn food
        Instantiate(foodPrefab);
    }

    //Medicate
        //Reduce creature sickness
}
