using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    float noteSpeed = 5;
    public bool isLastNote = false;
    UnityEngine.UI.Image noteImg;
    ESCMenu escMenu;

    private void Start()
    {
        escMenu = FindObjectOfType<ESCMenu>();
        noteImg = GetComponent<UnityEngine.UI.Image>();
        noteSpeed = PlayerPrefs.GetInt("noteSpeed");
    }

    private void Update()
    {
        if (!escMenu.isPop)
        {
            transform.localPosition += Vector3.right * noteSpeed * Time.deltaTime;
        }
    }

    public void HideNote()
    {
        noteImg.enabled = false;
    }
}
