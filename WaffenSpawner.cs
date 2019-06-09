using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaffenSpawner : MonoBehaviour
{   [SerializeField]
     private GameObject Plasma, Laser; //Which Weapon to spawn
    [SerializeField]
    private Transform WaffenSpawn; //Where the weapon will spawn


    private float waitTime = 25; //Time for the Weapon to Respawn;
    private float nextSpawn = 0;

    int whatToSpawn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawn)
       
        {
            whatToSpawn = Random.Range(1, 2);
            Debug.Log(whatToSpawn);

            switch (whatToSpawn)
            {
                case 1:
                    Instantiate(Plasma, WaffenSpawn.position, Quaternion.identity);
                    break;

                case 2:
                    Instantiate(Laser, WaffenSpawn.position, Quaternion.identity);
                    break;
                default:
                    break;
            }
            nextSpawn = Time.time + waitTime;
        }
    }
  
}
