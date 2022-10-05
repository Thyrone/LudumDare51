using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public int SceneToLoad;

  public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneToLoad));
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
           // Quitter();
        }
    }

    public void ResetLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex));
    }

    public void Quitter()
    {
        Application.Quit();
    }

    IEnumerator LoadLevel(int sceneforLoad)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(sceneforLoad);
    }
}
