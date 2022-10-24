using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelixManager : MonoBehaviour
{
    public GameObject[] helixRings;
    public Transform placeHolders;
    public float ySpawn = 0;
    public float ringDistance = 5;

    public int numberOfRings;

    // Start is called before the first frame update
    void Start()
    {
        numberOfRings = GameManager.currentLevelIndex + 5;

        // Spawn helix ring
        for(int i = 0; i < numberOfRings; i++)
        {
            if (i == 0)
                SpawnRing(0);
            else
                SpawnRing(Random.Range(3, helixRings.Length - 1));
        }

        // Spawn the last ring
        SpawnRing(helixRings.Length - 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnRing(int ringIndex)
    {
        GameObject go = Instantiate(helixRings[ringIndex], transform.up * ySpawn, Quaternion.identity);
        go.transform.parent = transform;

        // No place holder for the last ring
        if (helixRings.Length - 1 != ringIndex)
        {
            GameObject go1 = Instantiate(helixRings[1], transform.up * ySpawn, Quaternion.identity);
            go1.transform.parent = transform;
            GameObject go2 = Instantiate(helixRings[2], transform.up * ySpawn, Quaternion.identity);
            go2.transform.parent = placeHolders;
        }
        
        ySpawn -= ringDistance;
    }
}
