using System.Collections;
using TMPro;
using UnityEngine;

public class StartRun : MonoBehaviour
{

    float currCountDownValue;
    public TMP_Text CoundDownText;
    public GameObject CoundDownUI;
    public GameObject RetryUI;
    public TMP_Text TimerText;
    public float MaxtimerValue=10;
    private void Start()
    {
        RetryUI.SetActive(false);
        CoundDownUI.SetActive(false);
        StartCoroutine(StartTimer());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            StopAllCoroutines();
            RetryUI.SetActive(false); 
            LevelManager.Retry();
            StartCoroutine(StartTimer());
        }
    }

    public IEnumerator StartCountdown(float countdownValue)
    {
        currCountDownValue = countdownValue;
        while (currCountDownValue > 0)
        {
            CoundDownText.text = currCountDownValue.ToString();
            Debug.Log("Countdown: " + currCountDownValue);
            yield return new WaitForSeconds(1.0f);
            currCountDownValue--;
            
        }
        CoundDownUI.SetActive(false);
        LevelManager.Retry();
        StartCoroutine(StartTimer());
    }

    public IEnumerator StartTimer()
    {
        float timerValue = 0;
        while (timerValue < MaxtimerValue)
        {
           // Debug.Log("timerValue: " + timerValue);
            yield return new WaitForSeconds(0.01f);
            timerValue += 0.01f;
            TimerText.text = timerValue.ToString("F2") +"s";
        }
        LevelManager.Dead();
        RetryUI.SetActive(true);
    }



}
