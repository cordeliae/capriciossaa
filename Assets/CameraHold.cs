using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CameraHold : MonoBehaviour
{
    public Transform player;
    //public Transform cam;

    // Update is called once per frame
    void Update()
    {
        //    //4.4
        //    Ray ray = new Ray(transform.position, Vector3.back * 3f);
        //    Debug.DrawRay(transform.position, Vector3.back * 3f, Color.red, 1f);
        //    if (Physics.Raycast(ray, out RaycastHit hit, 3f))
        //    {
        //        Camera.main.transform.localPosition = new Vector3(0, 3f, -hit.distance);
        //    }
        //    else
        //    {
        //        Camera.main.transform.localPosition = new Vector3(0, 3f, -3f);
        //    }

        transform.position = player.position;
        transform.Rotate(0, Input.GetAxis("Mouse X") * 10f, 0);
    }
}
