using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetManager : MonoBehaviour
{
    public Text playerName;
    public Text clearStage;
    public Text totalScore;
    public Text noteSpeed;

    public GameObject BasePanel;
    public GameObject editNamePanel;
    public GameObject noteSpeedPanel;
    public InputField inputNewName;
    StageList stageList;

    private void Start()
    {
        stageList = FindObjectOfType<StageList>();
        editNamePanel.SetActive(false);
        SetText();
        SetTextNoteSpeed();
    }

    private void SetText()
    {
        playerName.text = PlayerPrefs.GetString("PlayerName");
        
        int clear = 0;
        int totalstage = stageList.LastIndex;
        int score = 0;
        for (int i = 0; i < totalstage+1; i++)    // clear한 스테이지 수
        {
            if (PlayerPrefs.GetInt("Stage" + i) != 0)
            {
                clear++;
                score += PlayerPrefs.GetInt("Stage" + i);
            }
        }
        clearStage.text = clear.ToString() + " / " + (totalstage + 1).ToString();
        totalScore.text = score.ToString();
    }

    public void NameBtnClick()
    {
        BasePanel.SetActive(false);
        noteSpeedPanel.SetActive(false);
        editNamePanel.SetActive(true);
    }

    public void EditNameCheckBtnClick()
    {
        PlayerPrefs.SetString("PlayerName", inputNewName.text);
        
        editNamePanel.SetActive(false);
        BasePanel.SetActive(true);
        noteSpeedPanel.SetActive(true);
        SetText();
    }

    public void SetTextNoteSpeed()
    {
        noteSpeed.text = PlayerPrefs.GetInt("noteSpeed").ToString();
    }

    public void ChangeNoteSpeed(int _value)
    {
        int speed = PlayerPrefs.GetInt("noteSpeed");

        speed += _value;
        if (speed < 30 || speed > 200) speed -= _value;

        PlayerPrefs.SetInt("noteSpeed", speed);
        SetTextNoteSpeed();
    }
}
