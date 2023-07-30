using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// The following script is used to check if a game object is grounded by casting a 2D ray downwards using a CapsuleCollider2D component.
// It also updates an Animator's bool parameter "isGrounded" based on the grounded status.
public class TouchingDirections : MonoBehaviour
{
    // A ContactFilter2D used to determine which colliders should be considered when casting the ray.
    public ContactFilter2D castFilter;
    // The distance of the ray casted from the object's CapsuleCollider2D.
    public float groundDistance = 0.05f;
    public float wallDistance = 0.2f;
    public float ceilingDistance = 0.05f;

    CapsuleCollider2D touchingCollider;
    Animator animator;

    // Array to store RaycastHit2D results when casting the ray.
    RaycastHit2D[] groundHits = new RaycastHit2D[5];
    RaycastHit2D[] wallHits = new RaycastHit2D[5];
    RaycastHit2D[] ceilingHits = new RaycastHit2D[5];

    [SerializeField]
    private bool _isGrounded;
    public bool IsGrounded
    {
        get
        {
            return _isGrounded;
        }
        set
        {
            _isGrounded = value;
            animator.SetBool(AnimationStrings.isGrounded, value);
        }
    }

    [SerializeField]
    private bool _isOnWall;
    public bool IsOnWall
    {
        get
        {
            return _isOnWall;
        }
        set
        {
            _isOnWall = value;
            animator.SetBool(AnimationStrings.isOnWall, value);
        }
    }

    [SerializeField]
    private bool _isOnCeiling;
    public bool IsOnCeiling
    {
        get
        {
            return _isOnCeiling;
        }
        set
        {
            _isOnCeiling = value;
            animator.SetBool(AnimationStrings.isOnCeiling, value);
        }
    }

    private Vector2 wallCheckDirection => gameObject.transform.localScale.x > 0 ? Vector2.right : Vector2.left;

    // Awake is called when the script instance is being loaded.
    private void Awake()
    {
        touchingCollider = GetComponent<CapsuleCollider2D>();
        animator = GetComponent<Animator>();
    }

    // FixedUpdate is called at fixed intervals and is commonly used for physics-related updates.
    void FixedUpdate()
    {
        // Cast a 2D ray downwards from the CapsuleCollider2D.
        // If the ray hits any colliders within the given groundDistance, consider the object as grounded.
        IsGrounded = touchingCollider.Cast(Vector2.down, castFilter, groundHits, groundDistance) > 0;
        IsOnWall = touchingCollider.Cast(wallCheckDirection, castFilter, wallHits, wallDistance) > 0;
        IsOnCeiling = touchingCollider.Cast(Vector2.up, castFilter, ceilingHits, ceilingDistance) > 0;
    }
}
