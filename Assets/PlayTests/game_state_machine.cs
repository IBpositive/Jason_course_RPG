using System;
using System.Collections;
using a_player;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Object = UnityEngine.Object;

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
        
        [UnityTest]
        public IEnumerator switches_to_play_when_level_to_load_completed()
        {
            // we destroy this in the test because we want a fresh start for each test.
            // without this the current test would be using the previous tests GameStateMachine
            GameObject.Destroy(Object.FindObjectOfType<GameStateMachine>());
            
            yield return Helpers.LoadMenuScene();
            var stateMachine = GameObject.FindObjectOfType<GameStateMachine>();
            
            Assert.AreEqual(typeof(Menu),stateMachine.CurrentStateType);
            PlayButton.LevelToLoad = "Level1";
            
            yield return null;

            Assert.AreEqual(typeof(LoadLevel),stateMachine.CurrentStateType);

            yield return new WaitUntil(() => stateMachine.CurrentStateType == typeof(Play));
            
            Assert.AreEqual(typeof(Play),stateMachine.CurrentStateType);
        }

        [UnityTest]
        public IEnumerator only_allows_one_instance_to_exist()
        {
            var firstGameStateMachine = new GameObject("First State Machine").AddComponent<GameStateMachine>();
            var secondGameStateMachine = new GameObject("Second State Machine").AddComponent<GameStateMachine>();
            yield return null;
            
            // has a weird error about the way null is handled.
            //Assert.IsNull(secondGameStateMachine);
            Assert.IsTrue(secondGameStateMachine == null);

            Assert.IsNotNull(firstGameStateMachine);


        }
        
    }
}