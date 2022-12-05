using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageInfoConvert : MonoBehaviour
{
    private int currentIndex;
    private int LastIndex;
    
    [SerializeField] Text stageTxt = null;
    [SerializeField] Text titleTxt = null;
    [SerializeField] Text composerTxt = null;
    [SerializeField] Text scoreTxt = null;

    StageList stageList;
    stage thisStageInfo;

    private void Awake()
    {
        stageList = FindObjectOfType<StageList>();  // stageList 오브젝트 연동
        currentIndex = stageList.currentStageID;    // 현재 인덱스 초기화
        LastIndex = stageList.LastIndex;            // 인덱스 개수 저장
        SelectStage(currentIndex);
    }

    private void SelectStage(int index)
    {
        CancelInvoke();
        stageList.StopThisBGM();
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(i == index);
        }
        stageList.currentStageID = index;   // stageList index 값 변경
        thisStageInfo = stageList.GetStageInfo(index);
        Debug.Log("현재 스테이지 정보: " + thisStageInfo.stagetxt + " / " + thisStageInfo.titletxt + " / " + thisStageInfo.composertxt);
        stageTxt.text = thisStageInfo.stagetxt;
        titleTxt.text = thisStageInfo.titletxt;
        composerTxt.text = thisStageInfo.composertxt;
        LoadScore();
        // 음악 출력
        Invoke("PlayBGM", 0.5f);
    }
    private void LoadScore()
    {
        scoreTxt.text = PlayerPrefs.GetInt("Stage" + currentIndex).ToString();
    }

    public void ChangeStage(int change)
    {
        currentIndex += change;
        if (currentIndex == LastIndex + 1)
            currentIndex = 0;
        else if (currentIndex == -1)
            currentIndex = LastIndex;

        SelectStage(currentIndex);
    }

    public void PlayBGM()
    {
        stageList.PlayThisBGM(currentIndex);
    }

    public int GetCurrentStageID()
    {
        return currentIndex;
    }
}
