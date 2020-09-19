using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WaveTimer : MonoBehaviour
{
    [SerializeField] private Text timerUI; //Able to edit in inspector
    [SerializeField] private float mainTimer;
    public Text WaveNumberText;


    public GameObject NewWaveText;
    public float UiTime = 3.0f;

    private float timer;
    private bool canCount = true;
    private bool doOnce = false;

    private int waveNumber;

    void Start()
    {
        timer = mainTimer;
    }

    void Update()
    {
        if(timer >= 0.0f && canCount)
        {
            timer -= Time.deltaTime;
            timerUI.text = timer.ToString("F");
        }

        else if(timer <= 0.0f && !doOnce)
        {
            canCount = false;
            doOnce = false;
            timerUI.text = "0.00";
            timer = 0.0f;
            NewWaveText.SetActive(true);
            ResetTimer();
        }
    }

    void ResetTimer()
    {
        canCount = true;
        doOnce = false;
        timer = 10f;
        Invoke("WaveTextTime", 2); //Use function WaveTextTime after 2 seconds
        WaveNumberText.text = "WAVE: " + waveNumber.ToString();
        waveNumber++;
    }

    void WaveTextTime()
    {
        NewWaveText.SetActive(false);
    }
}
