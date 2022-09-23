using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasPanels : MonoBehaviour
{
    [SerializeField]private LevelCompletedPanel _levelCompletedPanel;

    public void ShowLevelCompletedPanel()
    {
        _levelCompletedPanel.gameObject.SetActive(true);
    }
    
}
