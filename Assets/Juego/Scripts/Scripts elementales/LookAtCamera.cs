using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    public Transform Camera;

    void LateUpdate()
    {
        transform.LookAt(Camera);
    }
}
