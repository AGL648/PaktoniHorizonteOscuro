using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caja : MonoBehaviour
{
    public float empuje = 2f;
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody cuerpo = hit.collider.attachedRigidbody;

        if (cuerpo == null || cuerpo.isKinematic)
        {
            return;
        }
        if (hit.moveDirection.y < -0.3)
        {
            return;
        }

        Vector3 direccion = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);

        cuerpo.linearVelocity = empuje * direccion;
    }
}