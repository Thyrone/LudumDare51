using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{

    public Material mat1;
    public Material mat2;

    public Color colorPrimary1;
    public Color colorSecondary1;
    public Color colorPrimary2;
    public Color colorScondary2;
    public float time;

    private void Start()
    {
        mat1.SetColor("_BaseColor", colorPrimary2);
        mat1.SetColor("_1st_ShadeColor", colorScondary2);
        mat2.SetColor("_BaseColor", colorPrimary1);
        mat2.SetColor("_1st_ShadeColor", colorSecondary1);
        StartCoroutine(ChangeColorTime());
    }

    IEnumerator ChangeColorTime()
    {
        bool swap = true;
        while (true)
        {
            yield return new WaitForSeconds(time);
            if (swap)
            {
                Debug.Log("1");
                mat1.SetColor("_BaseColor", colorPrimary2);
                mat1.SetColor("_1st_ShadeColor", colorScondary2);
                mat2.SetColor("_BaseColor", colorPrimary1);
                mat2.SetColor("_1st_ShadeColor", colorSecondary1);
            }
            else
            {
                Debug.Log("2");
                mat1.SetColor("_BaseColor", colorPrimary1);
                mat1.SetColor("_1st_ShadeColor", colorSecondary1);
                mat2.SetColor("_BaseColor", colorPrimary2);
                mat2.SetColor("_1st_ShadeColor", colorScondary2);
            }
            swap = !swap;

        }

    }
}
