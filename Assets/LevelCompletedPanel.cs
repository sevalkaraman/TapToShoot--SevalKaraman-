using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LevelCompletedPanel : Panel
{
   [SerializeField] private Button retryButton;


   private void OnEnable()
   {
      retryButton.onClick.AddListener(OnRetryButtonClicked);
   }

   private void OnDisable()
   {
      retryButton.onClick.RemoveListener(OnRetryButtonClicked);
   }

   private void OnRetryButtonClicked()
   {
      SceneManager.LoadScene(0);
   }
}
