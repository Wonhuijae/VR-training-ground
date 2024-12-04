using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class PunchSandbag : MonoBehaviour
{
    // 힘 계수
    public float power = 5f;
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
        if(other.gameObject.name.Contains("Hand"))
        {
            rb.AddForce(other.transform.forward * power);

            int idx = Random.Range(0, hitClipCount);
            audioSource.PlayOneShot(hitClip[idx]);
        }
    }
}
