using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportBall : MonoBehaviour
{

    GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnCollisionEnter(Collision collision)
    {
        // check if you hit an enemy
        if (collision.gameObject.tag == "Teleportable")
        {
            // destroy projectile
            player.transform.position = gameObject.transform.position;
            Destroy(gameObject);
        }


    }
}
