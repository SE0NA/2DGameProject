using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonClickUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public AudioSource buttonAS;
    public AudioClip buttonClickAC;
    public AudioClip buttonHighlightedAC;

    public Sprite _buttonOriginSprite = null;
    public Sprite _buttonClickSprite = null;

    [SerializeField] bool isSizeChange = true;
    public Transform buttonScale;
    Vector3 defaultScale;

    private void Start()
    {
        _buttonOriginSprite = gameObject.GetComponent<Image>().sprite;
        defaultScale = buttonScale.localScale;
    }

    // 사이즈 변경
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (isSizeChange)
        {
            buttonScale.localScale = defaultScale * 1.1f;
            HighlightedSound();
        }
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        buttonScale.localScale = defaultScale;
    }

    // 마우스 클릭
    public void SpriteChangeOnMouseClick()
    {
        gameObject.GetComponent<Image>().sprite = _buttonClickSprite;
        Invoke("SpriteBackOriginal", 0.1f);
    }
    private void SpriteBackOriginal()
    {
        gameObject.GetComponent<Image>().sprite = _buttonOriginSprite;
    }

    public void ClickSound()
    {
        buttonAS.PlayOneShot(buttonClickAC);
    }
    public void HighlightedSound()
    {
        if (buttonHighlightedAC)
        {
            buttonAS.PlayOneShot(buttonHighlightedAC);
        }
    }
}
