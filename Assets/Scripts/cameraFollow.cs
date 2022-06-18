using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public GameObject targetObject;
    public Vector3 CameraOffset;

    private void Start()
    {
        
    }


    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = targetObject.transform.position + CameraOffset;
    }
}
