using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/*
 * 버튼에 마우스 포인터가 올라가면 버튼의 사이즈가 커지고
 * 빠져나가면 다시 원래대로 돌아온다.
 * + 효과음
 */

public class EnterButtonSizeUp : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Transform buttonScale;
    Vector3 defaultScale;

    public AudioSource buttonAS;
    public AudioClip HighlightedFx;

    private void Start()
    {
        defaultScale = buttonScale.localScale;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonScale.localScale = defaultScale * 1.1f;
        HighlightedSound();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        buttonScale.localScale = defaultScale;
    }

    void HighlightedSound()
    {
        buttonAS.PlayOneShot(HighlightedFx);
    }
}
