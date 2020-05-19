using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CyborgController : MonoBehaviour
{
    [Header("Cyborg Variables")]
    public float DetectionRange;

    [Header("Visible Variables")]
    public MoveComponent MoveComponent;

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
        }
    }
}
