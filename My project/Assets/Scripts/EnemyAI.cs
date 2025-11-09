using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{   
    public float detectionRange = 5f;
    public float speed = 2f;

    public Transform player;
    private Rigidbody2D rb;
    private Vector2 movement;
    private Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
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
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }
}
