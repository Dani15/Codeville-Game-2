using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float cameraSpeed;
    // Update is called once per frame
    void Update()
    {
        transform.position += new UnityEngine.Vector3(cameraSpeed * Time.deltaTime, 0, 0);
    }
}
