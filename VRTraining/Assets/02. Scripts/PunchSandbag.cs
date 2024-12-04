using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;

public class PunchSandbag : MonoBehaviour
{
    [SerializeField]
    InputActionReference leftAction;
    [SerializeField]
    InputActionReference rightAction;

    // 기본 힘
    public int power = 1;

    // 피격음
    public AudioClip[] hitClip;
    int hitClipCount = 0;

    Rigidbody rb;
    AudioSource audioSource;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();

        hitClipCount = hitClip.Length;
    }

    private void OnTriggerEnter(Collider other)
    {
        Vector3 leftVelocity = leftAction.action.ReadValue<Vector3>();
        Vector3 rightVelocity = rightAction.action.ReadValue<Vector3>();

        if (other.gameObject.name.Contains("LeftHand"))
        {
            ForceToSandbag(other.transform.forward, leftVelocity);
        }
        else if (other.gameObject.name.Contains("RightHand"))
        {
            ForceToSandbag(other.transform.forward, rightVelocity);
        }

        int idx = Random.Range(0, hitClipCount);
        audioSource.PlayOneShot(hitClip[idx]);
    }

    // 타격 시점 속도에 비례하여 힘 증가
    void ForceToSandbag(Vector3 _direction, Vector3 _velocity)
    {
        float v = _velocity.magnitude;
        rb.AddForce(_direction * v * power);
    }
}
