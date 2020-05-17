using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationManager : MonoBehaviour
{
    [Header("Visible Variables")]
    public SpriteRenderer SpriteRenderer;
    public Animator Animator;
    public PlayerController PlayerController;

    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
        Animator = GetComponent<Animator>();
        PlayerController = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = PlayerController.Direction;

        Animator.SetBool("down", direction.y < 0);
        Animator.SetBool("up", direction.y > 0);
        Animator.SetBool("side", direction.x != 0);

        SpriteRenderer.flipX = direction.x < 0;
    }
}
