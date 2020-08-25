using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bootstrapper 
{
   [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
   public static void Initialize()
   {
      var inputGameObject = new GameObject("[INPUT SYSTEM]");
      inputGameObject.AddComponent<PlayerInput>();
      GameObject.DontDestroyOnLoad(inputGameObject);
   }
}
