using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField]
    Transform muzzle;

    // 피격 위치 효과
    [SerializeField]
    GameObject[] bulletHoles;
    
    public float maxDistance = 10f;
    // 총알 발사 효과
    public ParticleSystem shotEffect;

    int bulletCount = 0;
    private void Awake()
    {
        bulletCount = bulletHoles.Length;
    }

    // 총알 발사
    public void Fire()
    {
        shotEffect.Play();

        RaycastHit hit;
        Physics.Raycast(muzzle.transform.position, muzzle.transform.forward, out hit, maxDistance);

        if (hit.collider != null)
        {
            int idx = Random.Range(0, bulletCount);
            var hole = Instantiate(bulletHoles[idx], hit.point, hit.transform.rotation);
            hole.transform.position += new Vector3(0, 0, 0.01f);

            Destroy(hole, 3f);
        }
    }
}
