using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpMoveScript : MonoBehaviour
{
    public float moveSpeed = 5;
    public float deadZone = -45;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;

        if (transform.position.x < deadZone)
        {
            Debug.Log("PowerUp Destroyed");
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.tag == "ExtraLife")
        {
            if (LogicScript.logicScript.playerLife != LogicScript.logicScript.maxLife)
            {
                LogicScript.logicScript.PlayLifeSFX();
                AddLife();
                Destroy(gameObject);
            }


        }

        else if (gameObject.tag == "Shield")
        {
            LogicScript.logicScript.PlayInvulSFX();
            CastInvul();
            Destroy(gameObject);
        }


    }

    void AddLife()
    {
        LogicScript.logicScript.playerLife++;
    }

    void CastInvul()
    {
        LogicScript.logicScript.invulnerable = true;
    }
}
