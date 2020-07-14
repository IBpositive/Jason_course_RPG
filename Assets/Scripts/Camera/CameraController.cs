using UnityEngine;

public class CameraController : MonoBehaviour
{
    private float _tilt;

    private void Update()
    {
        if (Pause.Active)
        {
            return;
        }
        
        float mouseRoataion = Input.GetAxis("Mouse Y");
        // to restrict how much the player can move the camera
        _tilt = Mathf.Clamp(_tilt - mouseRoataion, -15f, 15f);
        // the reason we edit the x axis instead of y when using "Mouse Y" has something
        // to do with 2d vs 3d and how they are viewed therein.
        transform.localRotation = Quaternion.Euler(_tilt, 0f, 0f);
    }
}
