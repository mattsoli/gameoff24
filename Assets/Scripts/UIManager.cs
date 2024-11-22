using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoSingleton<UIManager>
{
   [SerializeField] private GameObject _hackScreen, _toolsScreen;
   [SerializeField] private Button hammerBtn, pickaxeBtn;

   private void Start()
   {
      hammerBtn.onClick.AddListener(() => PlayerController.Instance.currentWeapon = 1);
      pickaxeBtn.onClick.AddListener(() => PlayerController.Instance.currentWeapon = 2);
   }

   public void ShowHackScreen()
   {
      _hackScreen.SetActive(true);
   }
   
   public void HideHackScreen()
   {
      _hackScreen.SetActive(false);
   }
   
   public void ShowToolsScreen()
   {
      _toolsScreen.SetActive(true);
   }
   
   public void HideToolsScreen()
   {
      _toolsScreen.SetActive(false);
   }
   

}
