using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 게임의 스테이지 정보를 저장하는 스크립트.
 * + 스테이지의 구조체
 */

public struct stage
{
    public int ID;
    public string stagetxt;
    public string titletxt;
    public string composertxt;
    public int bpm;
    public int noteTotal;
}

public class StageList : MonoBehaviour
{
    public List<stage> stageList;
    public List<AudioClip> bgmList;
    public AudioSource myAudioAS;

    public int currentStageID;
    public int LastIndex;

    void Awake()
    {
        stageList = new List<stage>
        {
            new stage{ ID=0, stagetxt="아마도 초급", titletxt="Track 2", composertxt="GWriterStudio", bpm=70, noteTotal=56}, 
            new stage{ ID=1, stagetxt="종이박스", titletxt="Deep In Space", composertxt="BREITBARTH", bpm=100, noteTotal=53},
        };
        DontDestroyOnLoad(gameObject);  // 게임이 종료될 때까지 적용됨
        currentStageID = 0;    // 처음 스테이지 ID를 0으로 초기화
        LastIndex = stageList.Count - 1;    // 마지막 인덱스 = 리스트 요소 개수 - 1
        myAudioAS = GetComponent<AudioSource>();

        if (PlayerPrefs.GetInt("noteSpeed") == 0) PlayerPrefs.SetInt("noteSpeed", 100);  // 노트 속도(처음)
    }

    public stage GetStageInfo(int id)
    {
        return stageList[id];
    }

    public void PlayThisBGM(int _index)
    {
        myAudioAS.PlayOneShot(bgmList[_index]);
    }
    public void StopThisBGM()
    {
        myAudioAS.Stop();
    }
}

