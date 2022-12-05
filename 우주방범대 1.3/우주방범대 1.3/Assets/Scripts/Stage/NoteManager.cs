using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *  bpm, noteTotal 값에 따라 노트의 속도, 개수를 설정
 *  인스턴스 노트를 생성
 */

public class NoteManager : MonoBehaviour
{
    private int bpm = 70;
    
    double currentTime = 0d;
    int noteTotal;
    int noteCnt = 0;

    [SerializeField] Transform _noteAppear = null;
    [SerializeField] GameObject _goNote = null;

    TimingManager timingManager;
    StageList stageList;
    GameManager gameManager;
    ESCMenu escMenu;

    private void Start()
    {
        timingManager = GetComponent<TimingManager>();
        stageList = FindObjectOfType<StageList>();
        gameManager = FindObjectOfType<GameManager>();
        escMenu = FindObjectOfType<ESCMenu>();
        bpm = stageList.stageList[stageList.currentStageID].bpm;
        noteTotal = stageList.stageList[stageList.currentStageID].noteTotal;
    }

    private void Update()
    {
        if (!escMenu.isPop)
        {
            currentTime += Time.deltaTime;
            if (noteCnt <= noteTotal)   // 끝X
            {
                if (currentTime >= 60d / bpm)  // 1 노트당 등장속도
                {
                    // 노트 생성
                    GameObject t_note = Instantiate(_goNote, _noteAppear.position, Quaternion.identity);
                    t_note.transform.SetParent(this.transform);
                    if (noteCnt == noteTotal) t_note.GetComponent<Note>().isLastNote = true;
                    noteCnt++;
                    timingManager.NoteList.Add(t_note);
                    currentTime -= 60d / bpm;   // 초기화
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Note"))
        {
            timingManager.NoteList.Remove(collision.gameObject);
            Destroy(collision.gameObject);
        }
    }
}
