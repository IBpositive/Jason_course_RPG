using System;
using System.Collections;
using a_player;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace state_machine
{
    public class game_state_machine
    {
        [UnityTest]
        public IEnumerator switches_to_loading_when_level_to_load_selected()
        {
            yield return Helpers.LoadMenuScene();
            var stateMachine = GameObject.FindObjectOfType<GameStateMachine>();
            
            Assert.AreEqual(typeof(Menu),stateMachine.CurrentStateType);
            PlayButton.LevelToLoad = "Level1";
            
            yield return null;

            Assert.AreEqual(typeof(LoadLevel),stateMachine.CurrentStateType);

        }
    }
}