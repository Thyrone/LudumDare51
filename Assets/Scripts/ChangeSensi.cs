using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSensi : MonoBehaviour
{
    PlayerCam PlayerCam;

    bool optionActive=false;
    // Start is called before the first frame update
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(!optionActive)
            {
                optionActive = true;
                transform.GetChild(0).gameObject.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }else
            {
                optionActive = false;
                transform.GetChild(0).gameObject.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }

        }
    }

public void ChangeSensibility(float sensi)
    {
        PlayerCam = FindObjectOfType<PlayerCam>();
        PlayerCam.sensX = sensi;
        PlayerCam.sensY = sensi;
    }
}
