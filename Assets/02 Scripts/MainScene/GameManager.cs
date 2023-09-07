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

    public GameObject inputFieldImg; //이름변경시 켜지고 끌 인풋필드를 가진 부모 이미지 UI
    public TMP_InputField playerNameInput; //인풋필드 UI

    public GameObject checkParticipantBar;
    public TextMeshProUGUI participantTxt;
    public GameObject player;

    private float currentTime;
    private bool isEnoughLongName = false; //이름변경시 이름길이 체크 불값 

    private string blank = System.Environment.NewLine;

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

    // 이름변경 로직 
    void GetName()
    {
        player.GetComponent<Characters>().characterName = InputManager.playerName;
        plName.text = InputManager.playerName;
    }

    public void NameChangeBtn()
    {
        Time.timeScale = 0;
        inputFieldImg.SetActive(true);
    }

    private void InputName()
    {
        player.GetComponent<Characters>().characterName = playerNameInput.text;
        plName.text = playerNameInput.text;
    }

    public void SubmitChangePlName()
    {
        InputName();

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
    //이름변경 로직 끝



    //참석자 표시
    public void OnClickOpenParticipantCheckBar()
    {
        checkParticipantBar.SetActive(true);

        for (int i = 0; i < PlayerManage.players.Count; i++)
        {
            participantTxt.text = PlayerManage.players[i].GetComponent<Characters>().characterName; //안됨...
        }
    }

    public void OnClickCloseParticipantCheckBar()
    {
        checkParticipantBar.SetActive(false);
    }
    //참석자표시 끝
}