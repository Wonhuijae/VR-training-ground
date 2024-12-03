using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIRotator : MonoBehaviour
{
    public GameObject cam;

    private void FixedUpdate()
    {
        Vector3 direction = - cam.transform.position + transform.position;

        transform.rotation = Quaternion.LookRotation(direction);
    }
}
