using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 *  점수 관리 스크립트
 *  - 점수를 출력하는 텍스트 관리
 *  - 점수 증가 및 감소 함수
 */

public class ScoreManager : MonoBehaviour
{
    [SerializeField] Text _scoreTxt = null;

    GameManager gameManager;

    private int currentScore = 0;   // 현재 점수

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        _scoreTxt.text = "0";   // 점수판 초기화
    }
    
    private void UpdateScoreTxt()       // 점수판 수정
    {
        _scoreTxt.text = currentScore.ToString();
    }
    
    public int GetCurrentScore()        // 현재 점수 반환
    {
        return currentScore;
    }

    // 점수 증가
    public void IncreaseScoreByJudgement(int level)     // 노트 판정으로 주는 기본 점수
    {
        // 0: perfect   1: good   2: bad
        if (level == 0)         currentScore += 5;  // perfect 판정 > 5점
        else if (level == 1)    currentScore += 3;  // good 판정    > 3점
        else if (level == 2)    currentScore += 1;  // bad 판정     > 1점
        UpdateScoreTxt();  
    }

    public void IncreaseScoreByAttackEnemy(int level, int point)   // 적 오브젝트를 공격하면 얻는 점수
    {
        gameManager.hitCnt++;
        int increase = (3 - level) * point; 
        currentScore += increase;
        UpdateScoreTxt();
    }

    // 점수 감소
    public void DecreaseScoreByHit()        // 공격에 맞으면 무조건 -5점
    {
        currentScore -= 5;
        if (currentScore < 0) currentScore = 0; // 최저 점수
        UpdateScoreTxt();
    }
}
