using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationManager : MonoBehaviour
{
    [Header("Visible Variables")]
    public SpriteRenderer SpriteRenderer;
    public Animator Animator;
    public MoveComponent MoveComponent;

    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
        Animator = GetComponent<Animator>();
        MoveComponent = GetComponent<MoveComponent>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = MoveComponent.Direction;

        if (direction != Vector3.zero)
        {
            Animator.SetBool("down", direction.y < 0);
            Animator.SetBool("up", direction.y > 0);
            Animator.SetBool("side", direction.x != 0);

            SpriteRenderer.flipX = direction.x < 0;
        }
    }
}
