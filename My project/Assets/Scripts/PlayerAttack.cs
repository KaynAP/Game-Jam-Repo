using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject slashEffectSide;
    public GameObject slashEffectUp;
    public GameObject slashEffectDown;

    public Transform attackSpwanPoint;


    public Animator animator;
    public Rigidbody2D rb;
    public float attackCooldown = 0.3f;
    private float attackTimer;
    private Vector2 lastMovementDirection = Vector2.down;

    private Vector2 lastMoveDirection;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }


    void Update()
    {
        attackTimer = Time.deltaTime;
        if (Input.GetMouseButtonDown(0) && attackTimer <= 0 && !animator.GetBool("IsAttacking"))
        {
            animator.SetBool("IsAttacking", true);
            rb.linearVelocity = Vector2.zero;
            attackTimer = attackCooldown;
            PlaySlashEffect();
        }

        lastMovementDirection = new Vector2(animator.GetFloat("Xinput"), animator.GetFloat("Yinput"));
    }
    void PlaySlashEffect()
    {
        GameObject prefabToSpawn = slashEffectSide;

        if (lastMoveDirection.y > 0.5f)
        {
            prefabToSpawn = slashEffectUp;
        }
        else
            if (lastMoveDirection.y < -0.5f)
        {
            prefabToSpawn = slashEffectDown;
        }
        else
            if(Mathf.Abs(lastMoveDirection.x) > 0.5f)
        {
             prefabToSpawn = slashEffectSide;
        }

        Instantiate(prefabToSpawn, attackSpwanPoint.position, Quaternion.identity);
    }

    public void SetLastMoveDirection (Vector2 dir)
    {
        if (dir != Vector2.zero)
        {
            lastMoveDirection = dir;
        }
    }

    public void ResetAttack()
    {
       animator.SetBool("IsAttacking", false);
    }
}

