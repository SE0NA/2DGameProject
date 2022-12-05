using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*
 *  결과창 출력과 점수 저장
 */

public class ResultManager : MonoBehaviour
{
    GameManager gameManager;
    ScoreManager scoreManager;
    StageList stageList;

    [SerializeField] GameObject stageImg = null;
    public Text stagetxt;
    public Text titletxt;
    public Text composertxt;
    public Text perfectCnt;
    public Text goodCnt;
    public Text badCnt;
    public Text hitCnt;
    public GameObject newTxt;
    public Text scoretxt;
    stage stageInfo;
    
    public void SetResultPanel()
    {
        gameManager = FindObjectOfType<GameManager>();
        scoreManager = FindObjectOfType<ScoreManager>();
        stageList = FindObjectOfType<StageList>();
        stageInfo = stageList.stageList[stageList.currentStageID];
        newTxt.SetActive(false);    // new 초기화

        SetStageImg();
        
        stagetxt.text = stageInfo.stagetxt;
        titletxt.text = stageInfo.titletxt;
        composertxt.text = stageInfo.composertxt;

        perfectCnt.text = gameManager.perfectCnt.ToString();
        goodCnt.text = gameManager.goodCnt.ToString();
        badCnt.text = gameManager.badCnt.ToString();
        hitCnt.text = gameManager.hitCnt.ToString();
        
        int thisScore = scoreManager.GetCurrentScore();
        int bestScore = PlayerPrefs.GetInt("Stage" + stageInfo.ID);
        scoretxt.text = thisScore.ToString();
        if (bestScore < thisScore)  // 신기록
        {
            newTxt.SetActive(true);
            PlayerPrefs.SetInt("Stage" + stageInfo.ID, thisScore);   // 기록저장
        }
    }

    private void SetStageImg()
    {
        for (int i = 0; i < stageImg.transform.childCount; i++)
        {
            stageImg.transform.GetChild(i).gameObject.SetActive(i == stageInfo.ID);
        }
    }

    public void ResultBtnClick()
    {
        SceneManager.LoadScene("Select");
    }
}
