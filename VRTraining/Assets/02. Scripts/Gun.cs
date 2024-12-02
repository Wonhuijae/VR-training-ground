using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField]
    Transform muzzle;

    public float maxDistance = 10f;
    // 총알 발사 효과
    public GameObject shotEffect;
    // 피격 위치 효과
    public GameObject bulletEffect;

    public void Fire()
    {
        Debug.Log("Fire");
        Instantiate(shotEffect, muzzle.position, muzzle.rotation);

        RaycastHit hit;
        Physics.Raycast(transform.position, transform.forward, out hit, maxDistance);
        if (hit.collider != null)
        {
            Instantiate(bulletEffect, hit.transform.position, Quaternion.identity);
        }
    }
}
