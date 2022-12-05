using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionManager : MonoBehaviour
{
    public GameObject BtnPanel = null;
    public GameObject Logo = null;
    
    void Start()
    {
        gameObject.SetActive(false);
    }
    
    public void OnOptionCheckBtnClick()
    {
        
        gameObject.SetActive(false);
        BtnPanel.SetActive(true);
        Logo.SetActive(true);
    }
}
