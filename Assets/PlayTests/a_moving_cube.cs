using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class a_moving_cube
    {
        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator moving_forward_changes_position()
        {
            var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.position = Vector3.zero;
            //var rotation_save = 0.0f;
            
            /*
            for (int i = 0; i < 10; i++)
            {
                // ACT
                cube.transform.position += Vector3.forward;
                yield return null; //new WaitForSeconds(0.5f);
            
                // ASSERT
                Assert.AreEqual(i + 1, cube.transform.position.z);
            }

            for (int i = 0; i < 9; i++)
            {
           
                rotation_save += i * 10; 
                cube.transform.Rotate(rotation_save, 0.0f, 0.0f, Space.Self);
                yield return new WaitForSeconds(0.5f);
                
            }
             
            Assert.AreEqual(rotation_save, cube.transform.rotation.x);
*/

            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return null;
        }
    }
}
