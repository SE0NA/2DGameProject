using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 첫 노트가 센터에 닿으면 음악 재생
 */

public class CenterManager : MonoBehaviour
{
    AudioSource myAudioAS;
    StageList stageList;
    GameManager gameManager;

    [SerializeField] GameObject _resultPanel = null;
    ResultManager resultManager;

    bool musicStart = false;

    void Start()
    {
        stageList = FindObjectOfType<StageList>();
        resultManager = FindObjectOfType<ResultManager>();
        gameManager = FindObjectOfType<GameManager>();
        myAudioAS = GetComponent<AudioSource>();
        _resultPanel.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision) // 음악 재생
    {
        if (collision.CompareTag("Note"))   // 노트 지나감
        {
            if (!musicStart)
            {
                myAudioAS.PlayOneShot(stageList.bgmList[stageList.currentStageID]);
                musicStart = true;
                gameManager.isStart = true;
            }
            if(collision.GetComponent<Note>().isLastNote)
            {
                Invoke("GameFinish", 2.0f);
            }
        }
    }
    public void GameFinish()    // 게임이 종료됨
    {
        _resultPanel.SetActive(true);
        resultManager.SetResultPanel();
    
    }
}
