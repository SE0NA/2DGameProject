using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteData : MonoBehaviour
{
    public GameObject DeletePanel;
    public GameObject btnPanel;
    public GameObject logoImg;
    public GameObject optionPanel;

    private void Start()
    {
        DeletePanel.SetActive(false);
    }
    
    public void DeleteDataCheck()
    {
        DeletePanel.SetActive(true);   // 삭제 확인
        optionPanel.SetActive(false);
    }

    public void DeleteSaveData()
    {
        PlayerPrefs.DeleteAll();
        YesSetPanelSetting();
    }

    private void YesSetPanelSetting()
    {
        DeletePanel.SetActive(false);
        btnPanel.SetActive(true);
        logoImg.SetActive(true);
        optionPanel.SetActive(false);
    }

    public void NoSetPanelSetting()
    {
        DeletePanel.SetActive(false);
        btnPanel.SetActive(true);
        logoImg.SetActive(true);
        optionPanel.SetActive(true);
    }
}
