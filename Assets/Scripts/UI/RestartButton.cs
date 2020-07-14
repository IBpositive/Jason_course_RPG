using System;
using UnityEngine;
using UnityEngine.UI;

public class RestartButton : Button
{
   private static RestartButton _instance;
   public static bool Pressed => _instance != null && _instance.IsPressed();

   private void Update()
   {
      if (_instance.IsPressed())
      {
         Debug.Log("Restart has been pressed");
      }
   }

   protected override void OnEnable()
   {
      _instance = this;
      base.OnEnable();
   }
}
