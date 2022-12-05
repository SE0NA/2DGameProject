using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ESCMenu : MonoBehaviour
{
    public bool isPop;

    [SerializeField] GameObject panelESC = null;
    [SerializeField] Button retryBtn;
    [SerializeField] Button continueBtn;
    [SerializeField] Button goMenuBtn;

    [SerializeField] AudioSource BGMAS = null;

    // Start is called before the first frame update
    void Awake()
    {
        isPop = false;
        panelESC.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))   // esc 일시정지 메뉴
        {
            isPop = true;
            BGMAS.Pause();
            panelESC.SetActive(true);
        }
    }

    public void ReBtnClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ContinueBtnClick()
    {
        panelESC.SetActive(false);
        isPop = false;
        BGMAS.UnPause();
    }

    public void GoMenuBtnClick()
    {
        SceneManager.LoadScene("Select");
    }
}
