/*
/// THANKS FOR DOWNLOADING THIS PROJECT!
/// This spaghett was written in a month and is open and free for you to use if you'd like. 
/// 
/// If you have any questions, statements, or recommendations don't be afraid to contact me.
*/

using UnityEngine;

public class CameraControls : MonoBehaviour
{
    float CameraMoveSpeed = 0.25f;
    [SerializeField]
    Camera MainCamera = null;

    void LateUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            MainCamera.transform.position = new Vector3 (MainCamera.transform.position.x, MainCamera.transform.position.y + CameraMoveSpeed, MainCamera.transform.position.z);
        }
        if (Input.GetKey(KeyCode.A))
        {
            MainCamera.transform.position = new Vector3(MainCamera.transform.position.x - CameraMoveSpeed, MainCamera.transform.position.y, MainCamera.transform.position.z);
        }
        if (Input.GetKey(KeyCode.S))
        {
            MainCamera.transform.position = new Vector3(MainCamera.transform.position.x, MainCamera.transform.position.y - CameraMoveSpeed, MainCamera.transform.position.z);
        }
        if (Input.GetKey(KeyCode.D))
        {
            MainCamera.transform.position = new Vector3(MainCamera.transform.position.x + CameraMoveSpeed, MainCamera.transform.position.y, MainCamera.transform.position.z);
        }
        if (MainCamera.orthographicSize >= 5 && MainCamera.orthographicSize <= 20)
        {
            MainCamera.orthographicSize -= Input.mouseScrollDelta.y;
        }
        else if (MainCamera.orthographicSize <= 5)
        {
            MainCamera.orthographicSize = 5;

        }
        else if (MainCamera.orthographicSize >= 20)
        {
            MainCamera.orthographicSize = 20;
        }

    }
}
