using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    Material mat;
   Collider col;

    void Start()
    {
        mat = GetComponent<Renderer>().material;
        col = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        if(mat.color==LevelManager.currentColor)
        {
            col.isTrigger = true;
        }else
        {
            col.isTrigger = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Ball")
        {
            col.isTrigger = false;
            GetComponent<Renderer>().material.color = LevelManager.BallColor;
            Destroy(other);
        }
    }

}
