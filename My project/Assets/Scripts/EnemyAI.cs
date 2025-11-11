using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [Header("Enemy Settings")]
    public float detectionRange = 12f;
    public float speed = 7f;

    [Header("References")]
    public Transform player;
    private Rigidbody2D rb;
    private Vector2 movement;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.position);
        if (distance < detectionRange)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            movement = direction;
            animator.SetFloat("Xinput", direction.x);
            animator.SetFloat("Yinput", direction.y);
            animator.SetFloat("Speed", movement.magnitude);
        }
        else
        {
            movement = Vector2.zero;
            animator.SetFloat("Speed", 0);
        }

        if (movement.x < 0)
            spriteRenderer.flipX = true;
        else if (movement.x > 0)
            spriteRenderer.flipX = false;
        
            Debug.DrawLine(transform.position, player.position, Color.red);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }
}
