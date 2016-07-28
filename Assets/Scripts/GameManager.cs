using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    //VARIABLES
    //Creature Prefab
    public GameObject creaturePrefab;
    //Poop Prefab
    //Food Prefab

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
	}

    //Spawn
    void Spawn()
    {
        //Instantiate creature and set it to creature reference
        creatureRef = Instantiate(creaturePrefab);
    }

    //Clean
        //Remove all poop, reset creature poop number, reset creature hygiene

    //Feed
        //Spawn food

    //Medicate
        //Reduce creature sickness
}
