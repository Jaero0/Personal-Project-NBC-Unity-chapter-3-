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

    public GameObject inputFieldImg; //�̸������ ������ �� ��ǲ�ʵ带 ���� �θ� �̹��� UI
    public TMP_InputField playerNameInput; //��ǲ�ʵ� UI

    public GameObject checkParticipantBar;
    public TextMeshProUGUI participantTxt;
    public GameObject player;

    private float currentTime;
    private bool isEnoughLongName = false; //�̸������ �̸����� üũ �Ұ� 

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

    void CalcTime() //���� ���ýð� & �����ð�
    {
        currentTime += Time.deltaTime;

        DateTime time = DateTime.Now;
        localTime.text = "���� �ð� : " + time.ToString("HH:mm:ss");

        gameTime.text = "���� �ð� : " + currentTime.ToString("N1");
    }

    // �̸����� ���� 
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
    //�̸����� ���� ��



    //������ ǥ��
    public void OnClickOpenParticipantCheckBar()
    {
        checkParticipantBar.SetActive(true);

        for (int i = 0; i < PlayerManage.players.Count; i++)
        {
            participantTxt.text = PlayerManage.players[i].GetComponent<Characters>().characterName; //�ȵ�...
        }
    }

    public void OnClickCloseParticipantCheckBar()
    {
        checkParticipantBar.SetActive(false);
    }
    //������ǥ�� ��
}