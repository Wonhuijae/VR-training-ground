using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class PunchSandbag : MonoBehaviour
{
    // 힘 계수
    public float power = 5f;
    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name.Contains("Hand"))
        {
            rb.AddForce(other.transform.forward * power);
        }
    }
}
