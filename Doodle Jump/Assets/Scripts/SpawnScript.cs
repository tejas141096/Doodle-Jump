using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour {

    public GameObject[] obj;
    float top = -4f;
    bool flag = true;
    
    public GameObject player;

	// Use this for initialization
	void Start () {
        for(int i=0;i<6;i++)
        {
            float r = Random.Range(1f, 2f);
            top += r;
            Vector2 pos= new Vector2(Random.Range(-3, 3), top);
            Instantiate(obj[Random.Range(0, obj.Length)], pos, Quaternion.identity);
        }
        if(((int)(player.transform.position.y)%4) >= 3)
            Spawn();
	}

    void Update()
    {
        Debug.Log(player.transform.position.y);
        if ((((player.transform.position.y) % 4.0f) >= 3f) && flag)
        {
            Spawn();
            flag = false;
        }
        if ((((player.transform.position.y) % 4.0f) < 3f) && (((player.transform.position.y) % 4.0f) > 2f) && !flag)
        {
            flag = true;
        }
    }

    void Spawn()
    {
        for (int i = 0; i < 3; i++)
        {
            float r = Random.Range(1f, 2f);
            top += r;
            Vector2 pos = new Vector2(Random.Range(-3, 3), top);
            Instantiate(obj[Random.Range(0, obj.Length)], pos, Quaternion.identity);
        }
    }
}

/*

public class Spawner : MonoBehaviour
{
    // Here's where we define our weighted object structure,
    // and flag it Serializable so it can be edited in the Inspector.
    [System.Serializable]
    public struct Spawnable
    {
        public GameObject gameObject;
        public float weight;
    }

    // Now expose an array of these to be populated in the Inspector.
    public Spawnable[] spawnList;

    // Track the total weight used in the whole array.
    float _totalSpawnWeight;

    // Update the total weight when the user modifies Inspector properties,
    // and on initialization at runtime.
    void OnValidate()
    {
        _totalSpawnWeight = 0f;
        foreach (var spawnable in spawnList)
            _totalSpawnWeight += spawnable.weight;
    }

    // As Problematic points out below, OnValidate isn't called
    // in a built executable. But in that case we don't need to react
    // to a user fiddling with the Inspector mid-game, so it suffices
    // to run this code once during Awake:
    void Awake()
    {
        OnValidate();
    }

    // Spawn an item randomly, according to the relative weights.
    public void Spawn()
    {
        // Generate a random position in the list.
        float pick = Random.value * _totalSpawnWeight;
        int chosenIndex = 0;
        float cumulativeWeight = spawnList[0].weight;

        // Step through the list until we've accumulated more weight than this.
        // The length check is for safety in case rounding errors accumulate.
        while (pick > cumulativeWeight && chosenIndex < spawnList.length - 1)
        {
            chosenIndex++;
            cumulativeWeight += spawnList[chosenIndex].weight;
        }

        // Spawn the chosen item.
        Instantiate(spawnList[chosenIndex].gameObject, transform.position, transform.rotation);
    }
}*/