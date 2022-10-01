using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintBall : MonoBehaviour
{
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    private void OnCollisionEnter(Collision collision)
    {        
        // check if you hit an enemy
        if(collision.gameObject.tag=="Paintable")
        {
            // destroy projectile
            collision.gameObject.GetComponent<Renderer>().material.color = LevelManager.BallColor;
            Destroy(gameObject);
           
        }

    }
}
