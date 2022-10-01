using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public Camera cam;
    public Color color1;
    public Color color2;
    public AudioSource music;
   static public Color currentColor;
   static public Color BallColor;

    public float timeToChange;

    public bool ChangeColor=true;
    bool MusicLauch=false;

    static Vector3 spawnPlayerPos;
    static Quaternion spawnPlayerRot;
    static GameObject Player;
    static PlayerMovementAdvanced playerMovementAdvanced;
    static PlayerCam playerCam;
    static ThrowingTutorial throwing;
    static int baseTrowingObject;



    public static LevelManager instance { get; private set; }
    void Awake()
    {
        if (instance != null && instance != this)
            Destroy(gameObject); 

        instance = this;
    }

    void Start()
    {
        playerMovementAdvanced = FindObjectOfType<PlayerMovementAdvanced>();
        playerCam =  FindObjectOfType<PlayerCam>();
        throwing = FindObjectOfType<ThrowingTutorial>();
        Player = GameObject.FindGameObjectWithTag("Player");
        spawnPlayerPos = Player.transform.position;
        spawnPlayerRot = Player.transform.rotation;
        baseTrowingObject = throwing.totalThrows;

        cam.backgroundColor = color1;
        StartCoroutine(ChangeColorTime());
    }

    public static void Retry()
    {
        Player.transform.position = spawnPlayerPos;
        Player.transform.rotation= spawnPlayerRot;
        throwing.totalThrows = baseTrowingObject;
        playerMovementAdvanced.Locked = false;
        playerCam.Locked = false;
    }

    public static void Dead()
    {
        playerMovementAdvanced.Locked = true;
        playerCam.Locked = true;
    }   

    IEnumerator ChangeColorTime()
    {
        while (ChangeColor)
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
