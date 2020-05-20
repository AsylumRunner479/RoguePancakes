using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CyborgController : MonoBehaviour
{
    [Header("Cyborg Variables")]
    public float DetectionRange;

    [Header("Gun Variables")]
    public GameObject Bullet;
    public float BulletRange;
    public float BulletSpeed;
    public float FireRate;

    [Header("Visible Variables")]
    public MoveComponent MoveComponent;
    public float ReloadTime;

    // Start is called before the first frame update
    void Start()
    {
        MoveComponent = GetComponent<MoveComponent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.SqrMagnitude(PlayerController.Instance.transform.position - transform.position) < DetectionRange * DetectionRange)
        {
            Vector3 direction = Vector3.Normalize(PlayerController.Instance.transform.position - transform.position);
            MoveComponent.SetDirection(direction);

            if (ReloadTime <= 0)
            {
                FireBullet();
                ReloadTime = FireRate;
            } else
            {
                ReloadTime -= Time.deltaTime;
            }

        }
    }

    void FireBullet()
    {
        GameObject bullet = Instantiate(Bullet);
        bullet.transform.position = transform.position;
        bullet.GetComponent<BulletController>().FireBullet(PlayerController.Instance.transform.position, BulletSpeed, BulletRange);
    }
}
