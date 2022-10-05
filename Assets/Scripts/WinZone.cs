using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinZone : MonoBehaviour
{
    public TMP_Text WinScore;
    public TMP_Text WinHighScore;
    float HighScore;
    private void Start()
    {
        if(PlayerPrefs.HasKey(SceneManager.GetActiveScene().name))
        {
            HighScore = PlayerPrefs.GetFloat(SceneManager.GetActiveScene().name);
        }else
        {
            PlayerPrefs.SetFloat(SceneManager.GetActiveScene().name,LevelManager.MaxtimerValueStatic);
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            LevelManager.Win();
            WinScore.text = "Your score :" + LevelManager.timerValue.ToString("F2") + "s";
            if (LevelManager.timerValue< HighScore)
            {
                PlayerPrefs.SetFloat(SceneManager.GetActiveScene().name, LevelManager.timerValue);
            }
            WinHighScore.text = "Highscore : " + PlayerPrefs.GetFloat(SceneManager.GetActiveScene().name).ToString("F2") + "s";
            Debug.Log("CC");
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else if (other.tag == "Ball")
            Destroy(other);
    }
}
