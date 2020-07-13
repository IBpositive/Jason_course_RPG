using System.Collections;
using a_player;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace state_machine
{
    public class entity_state_machine
    {
        [UnityTest]
        public IEnumerator starts_in_idle_state()
        {
            yield return Helpers.LoadEntityStateTestScene();
            var stateMachine = GameObject.FindObjectOfType<EntityStateMachine>();
            // we can't access the specific state machies, so that's why we have this CurrentStateType
            Assert.AreEqual(typeof(Idle), stateMachine.CurrentStateType);
        }
        
        [UnityTest]
        public IEnumerator switches_to_chase_player_state_when_in_chase_range()
        {
            yield return Helpers.LoadEntityStateTestScene();

            var player = Helpers.GetPlayer();
            
            var stateMachine = GameObject.FindObjectOfType<EntityStateMachine>();
            // we can't access the specific state machies, so that's why we have this CurrentStateType
            
            player.transform.position = stateMachine.transform.position + new Vector3(5.1f, 0, 0);
            yield return null;
            Assert.AreEqual(typeof(Idle), stateMachine.CurrentStateType);
            player.transform.position = stateMachine.transform.position + new Vector3(4.9f, 0, 0);
            yield return null;
            Assert.AreEqual(typeof(ChasePlayer), stateMachine.CurrentStateType);

        }
    }
}