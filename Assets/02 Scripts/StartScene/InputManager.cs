using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class InputManager : MonoBehaviour
{
    public TMP_InputField playerNameInput;

    public static string playerName;
    private bool isEnoughLongName = false;

    void InputName()
    {
        playerName = playerNameInput.text;
    }

    void CheckValidName()
    {
        InputName();

        if (1 < playerName.Length && playerName.Length < 11)
        {
            isEnoughLongName = true;
        }
    }

    public void OnClickChangeToMainScene()
    {
        CheckValidName();
        if (isEnoughLongName)
        {
            SceneManager.LoadScene("MainScene");
        }
    }
}
