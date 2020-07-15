using System.Collections;
using NSubstitute;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace a_player
{
    public static class Helpers
    {
        public static IEnumerator LoadMovementTestsScene()
        {
            var operation = SceneManager.LoadSceneAsync("MovementTest");
            while (operation.isDone == false)
                yield return null;
        }

        public static IEnumerator LoadItemTestScene()
        {
            var operation = SceneManager.LoadSceneAsync("ItemTests");
            while (operation.isDone == false)
                yield return null;

            // LoadSceneMode.Additive will add the scene along with w/e else is there
            // Sort of like having multiple scenes in section 7
            operation = SceneManager.LoadSceneAsync("UI", LoadSceneMode.Additive);
            while (operation.isDone == false)
                yield return null;
        }

        public static IEnumerator LoadEntityStateTestScene()
        {
            var operation = SceneManager.LoadSceneAsync("EntityStateMachineTests");
            while (operation.isDone == false)
                yield return null;
        }

        public static IEnumerator LoadMenuScene()
        {
            var operation = SceneManager.LoadSceneAsync("Menu");
            while (operation.isDone == false)
                yield return null;
        }

        public static Player GetPlayer()
        {
            Player player = GameObject.FindObjectOfType<Player>();
            return player;
        }

        public static float CalculateTurn(Quaternion originalRotation, Quaternion transformRotation)
        {
            var cross = Vector3.Cross(originalRotation * Vector3.forward, transformRotation * Vector3.forward);
            var dot = Vector3.Dot(cross, Vector3.up);
            return dot;
        }
    }
}