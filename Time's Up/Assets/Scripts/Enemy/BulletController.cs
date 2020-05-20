using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [Header("Visible Variables")]
    public Vector3 StartPosition;
    public Vector3 TargetPosition;
    public float Range;

    public MoveComponent MoveComponent;
    public Vector3 Direction;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveComponent.SetDirection(Vector3.Normalize(TargetPosition - StartPosition));

        if (Vector3.SqrMagnitude(transform.position - StartPosition) > Range * Range)
            Destroy(gameObject);
    }

    public void FireBullet(Vector3 _target, float _speed, float _range)
    {
        StartPosition = transform.position;
        TargetPosition = _target;
        MoveComponent = GetComponent<MoveComponent>();
        MoveComponent.SetSpeed(_speed);
        Range = _range;

        Vector3 direction = (TargetPosition - StartPosition).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion angleQ = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = angleQ;
    }
}
