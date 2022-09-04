using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Rendering;

public class DropDown : MonoBehaviour
{
    public RenderPipelineAsset[] qualityLevels;
    public TMP_Dropdown dropDown;
    
    void Start()
    {
        dropDown.value = QualitySettings.GetQualityLevel();
        dropDown.value = Screen.currentResolution.height;
        Debug.Log(Screen.currentResolution.height);
    }

    public void ChangeLevel(int value)
    {
        QualitySettings.SetQualityLevel(value);
        QualitySettings.renderPipeline = qualityLevels[value];
    }

    public void ChangeResolution(int value)
    {
        switch (value) 
        {
            case 0:
                Resolution1920();
                break;
            case 1:
                Resolution1280();
                break;
            case 2:
                Resolution720();
                break;
        }
    }

    public void Resolution1920()
    {
        Screen.SetResolution(1920, 1080, true);
    }

    public void Resolution1280()
    {
        Screen.SetResolution(1280, 720, true);
    }

    public void Resolution720()
    {
        Screen.SetResolution(720, 408, true);
    }
}
