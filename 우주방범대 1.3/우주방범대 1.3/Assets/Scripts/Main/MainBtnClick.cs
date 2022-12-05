using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum MainBtn
{
    START, OPTION, QUIT
}

public class MainBtnClick : MonoBehaviour
{
    public MainBtn currentBtn;
    public GameObject btnPanel;
    public GameObject logoImg;
    public GameObject optionPanel;

    public AudioSource myAudioAS;
    public AudioClip PressedFx;
    
    public void OnBtnClick()
    {
        switch (currentBtn)
        {
            case MainBtn.START:
                myAudioAS.PlayOneShot(PressedFx);
                SceneManager.LoadScene("Select");
                break;

            case MainBtn.OPTION:
                myAudioAS.PlayOneShot(PressedFx);
                btnPanel.SetActive(false);
                logoImg.SetActive(false);
                optionPanel.SetActive(true);
                break;

            case MainBtn.QUIT:
                myAudioAS.PlayOneShot(PressedFx);
                Application.Quit();
                break;
        }
    }
}
