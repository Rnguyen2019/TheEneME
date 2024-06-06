using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFunction : MonoBehaviour
{
    public Camera cam;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(cam.orthographicSize - Input.mouseScrollDelta.y <= 20f && cam.orthographicSize - Input.mouseScrollDelta.y >= 5f){
            cam.orthographicSize -= Input.mouseScrollDelta.y;
        }
        if(Input.GetMouseButton(2)){
        }
    }
}
