using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *  각 노트의 타이밍
 */

public class TimingManager : MonoBehaviour
{
    public List<GameObject> NoteList = new List<GameObject>();

    [SerializeField] Transform Center = null;
    [SerializeField] RectTransform[] timingRect = null;
    Vector2[] timingBox = null;

    private void Start()
    {
        timingBox = new Vector2[timingRect.Length];

        for(int i = 0; i < timingRect.Length; i++)
        {
            timingBox[i].Set(Center.localPosition.x - timingRect[i].rect.width / 2,
                             Center.localPosition.x + timingRect[i].rect.width / 2);
        }
    }

    public int CheckTiming()
    {
        for(int i = 0; i < NoteList.Count; i++)
        {
            float t_notePosX = NoteList[i].transform.localPosition.x;
            for(int x = 0; x < timingBox.Length; x++)
            {
                if(timingBox[x].x <= t_notePosX && t_notePosX <= timingBox[x].y)
                {
                    NoteList[i].GetComponent<Note>().HideNote();
                    NoteList.RemoveAt(i);
                    return x;   // 박스 번호 = level
                }
            }
        }
        return -1;  // miss
    }
}
