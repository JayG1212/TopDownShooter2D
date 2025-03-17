using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedCameraRotation : MonoBehaviour
{
    public Vector3 fixedRotation = new Vector3(0, 0, 0);

    private void LateUpdate()
    {
        transform.rotation = Quaternion.Euler(fixedRotation);
    }

}
