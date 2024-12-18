using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawnerScript : MonoBehaviour
{
    public GameObject spawnPoint;
    public GameObject ExtraLife;
    public GameObject Shield;

    // Start is called before the first frame update
    void Start()
    {
        SpawnPowerUp();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnPowerUp()
    {
        int random_val = Random.Range(0, 100);
        //Debug.Log(random_val);

        if (random_val > 50 && random_val < 100)
        {
            //Nothing >:)
        }       

        else if (random_val > 15 && random_val < 50)
        {
            GameObject powerUp = Instantiate(Shield);
            powerUp.transform.position = spawnPoint.transform.position;
        }

        else if(random_val > 0 && random_val < 15)
        {
            GameObject powerUp = Instantiate(ExtraLife);
            powerUp.transform.position = spawnPoint.transform.position;
        }


    }
}
