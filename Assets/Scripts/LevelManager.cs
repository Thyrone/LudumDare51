using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static Camera cam;
    public Color color1;
    public Color color2;
    public AudioSource music;
    public GameObject player; 
    public TMP_Text TimerText;
    public float MaxtimerValue = 10;
    public static float MaxtimerValueStatic = 10;

    static public GameObject StaticGameOverUI;
    static public GameObject StaticWinUI;
    public GameObject GameOverUI;
    public GameObject WinUI;

    public Transform spawn;
   static public Color currentColor;
   static public Color BallColor;

    public float timeToChange;

    public bool ChangeColor=true;
    bool MusicLauch=false;

    static Vector3 spawnPlayerPos;
    static Vector3 spawnPlayerRot;
    static Transform Originalspawn;


    static GameObject CurrentPlayer;
    static GameObject CurrentPlayerAndCam;
    static GameObject OrigialPlayerAndCam;
    static PlayerMovementAdvanced playerMovementAdvanced;
    static PlayerCam playerCam;
    static ThrowingTutorial []throwing;
    static int[] baseTrowingObject;
    static public float timerValue = 0;
    static bool PlayerWin = false;


    public static LevelManager instance { get; private set; }
    void Awake()
    {
        if (instance != null && instance != this)
            Destroy(gameObject); 

        instance = this;
        OrigialPlayerAndCam = player;
        Originalspawn = spawn;
        StaticGameOverUI = GameOverUI;
        StaticWinUI = WinUI;
        currentColor = color1;
        BallColor = color2;
        MaxtimerValueStatic = MaxtimerValue;
        SetUpPlayer();
        StartCoroutine(ChangeColorTime());
        StartCoroutine(StartTimer(MaxtimerValue, TimerText));
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Retry();
        }
    }
    public static void SetUpPlayer()
    {
        CurrentPlayerAndCam = Instantiate(OrigialPlayerAndCam);
        playerMovementAdvanced = CurrentPlayerAndCam.GetComponentInChildren<PlayerMovementAdvanced>();
        CurrentPlayer = playerMovementAdvanced.gameObject;
        CurrentPlayer.transform.position = Originalspawn.transform.position;
        CurrentPlayer.transform.rotation = Originalspawn.transform.rotation;
        playerCam = CurrentPlayerAndCam.GetComponentInChildren<PlayerCam>();
        cam= playerCam.GetComponentInChildren<Camera>();
        cam.backgroundColor = currentColor;
        throwing = CurrentPlayerAndCam.GetComponentsInChildren<ThrowingTutorial>();
        CurrentPlayer = GameObject.FindGameObjectWithTag("Player");
        spawnPlayerPos = CurrentPlayer.transform.position;
        Debug.Log("throwing[0].totalThrows" + throwing[0].totalThrows);
        Debug.Log("throwing[1].totalThrows" + throwing[1].totalThrows);
        baseTrowingObject=new int [throwing.Length];
        for (int i = 0; i < throwing.Length-1; i++)
        {
            Debug.Log("i=" + throwing[i].totalThrows);
            baseTrowingObject[i] = throwing[i].totalThrows;
        }
    }

    public static void Retry()
    {/*
        if(CurrentPlayerAndCam!=null)
        {
          //  Destroy(CurrentPlayerAndCam);
        }
        //SetUpPlayer();

        CurrentPlayer.transform.position = spawnPlayerPos;
        for (int i = 0; i < baseTrowingObject.Length; i++)
        {
            throwing[i].totalThrows = baseTrowingObject[i];
        }
        playerMovementAdvanced.Locked = false;
       // Input.ResetInputAxes();
        //Debug.Log("Inputs" + Input.GetAxisRaw("Mouse X") + "/" + Input.GetAxisRaw("Mouse Y"));
       playerCam.Locked = false;
        */
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public static void Dead()
    {
        Debug.Log("Dead");
        StaticGameOverUI.SetActive(true);
        playerMovementAdvanced.Locked = true;
        playerCam.Locked = true;
    }

    public static void Win()
    {
        Debug.Log("Win");
        StaticWinUI.SetActive(true);
        playerMovementAdvanced.Locked = true;
        playerCam.Locked = true;
    }

    IEnumerator ChangeColorTime()
    {
        while (ChangeColor)
        {
            if(cam!=null)
            {
                if (cam.backgroundColor == color1)
                {
                    cam.backgroundColor = color2;
                    currentColor = color2;
                    BallColor = color1;
                }
                else
                {
                    cam.backgroundColor = color1;
                    currentColor = color1;
                    BallColor = color2;
                }
                if (!MusicLauch)
                {
                    MusicLauch = true;
                    music.Play();
                }
                yield return new WaitForSeconds(timeToChange);
            }
        }
    }

    static public IEnumerator StartTimer(float MaxtimerValuertmp,TMP_Text TimerTxttmp)
    {
        timerValue = 0;
        while (timerValue < MaxtimerValuertmp&& !PlayerWin)
        {
            // Debug.Log("timerValue: " + timerValue);
            yield return new WaitForSeconds(0.01f);
            timerValue += 0.01f;
            TimerTxttmp.text = timerValue.ToString("F2") + "s";
        }
        if(!PlayerWin)
            Dead();
    }


}
