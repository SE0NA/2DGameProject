using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectGetKey : MonoBehaviour
{
    StageList stageList;

    [SerializeField] Button leftBtn = null;
    [SerializeField] Button rightBtn = null;

    private void Start()
    {
        stageList = FindObjectOfType<StageList>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))    // 게임 시작
        {
            stageList.StopThisBGM();
            SceneManager.LoadScene("Stage");
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            leftBtn.onClick.Invoke();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            rightBtn.onClick.Invoke();
        }
    }
}
