using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI localTime;
    public TextMeshProUGUI gameTime;
    public TextMeshProUGUI plName;

    public GameObject inputFieldImg;
    public TMP_InputField playerNameInput;

    private float currentTime;
    private bool isEnoughLongName = false;

    void Start()
    {
        Time.timeScale = 1;
        GetName();
    }
    
    void Update()
    {
        CalcTime();
    }

    void CalcTime() //현재 로컬시간 & 생존시간
    {
        currentTime += Time.deltaTime;

        DateTime time = DateTime.Now;
        localTime.text = "현재 시간 : " + time.ToString("HH:mm:ss");

        gameTime.text = "생존 시간 : " + currentTime.ToString("N1");
    }

    void GetName()
    {
        plName.text = InputManager.playerName;
    }

    public void NameChangeBtn()
    {
        Time.timeScale = 0;
        inputFieldImg.SetActive(true);
    }

    private void InputName()
    {
        plName.text = playerNameInput.text;
    }

    public void SubmitChangePlName()
    {
        plName.text = playerNameInput.text;

        if (1 < plName.text.Length && plName.text.Length < 11)
        {
            isEnoughLongName = true;
        }
        else
        {
            isEnoughLongName = false;
        }
    }

    public void OnClickChangeName()//9.7 
    {
        SubmitChangePlName();

        if (isEnoughLongName)
        {
            Time.timeScale = 1;
            inputFieldImg.SetActive(false);
        }
    }
}