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

        mat.SetColor("_BaseColor", Random.Range(0, 2) == 1 ? LevelManager.BallColor : LevelManager.currentColor);
        

        //mat.color = Random.Range(0, 2) == 1 ? LevelManager.BallColor : LevelManager.currentColor;
    }

    // Update is called once per frame
    void Update()
    {
        if (mat.GetColor("_BaseColor")== LevelManager.currentColor)
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
            mat.SetColor("_BaseColor", LevelManager.BallColor);
           // mat.color = LevelManager.BallColor;
            Destroy(other);
        }
    }

}
