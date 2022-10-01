using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper : MonoBehaviour
{
    public float bumperSpeed=1000f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Coucou");
            collision.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * bumperSpeed);
        }
    }
}
