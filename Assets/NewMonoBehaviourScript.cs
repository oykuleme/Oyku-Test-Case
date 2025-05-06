using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public float speed = 5f;
    public float runSpeed = 8f;
    public float jumpForce = 10f;

    [Header("Mermi Ayarları")]
    public GameObject bulletPrefab;
    public Transform atisNoktasi;
    public float bulletSpeed = 10f;
    public float atesSikligi = 0.5f;
    private float atesZamani = 0f;

    private Rigidbody2D rb;
    private Animator animator;
    private bool isGrounded;
    private bool isRunning;
    private bool isFacingRight = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float move = Input.GetAxis("Horizontal");
        isRunning = Input.GetKey(KeyCode.LeftShift);

        float currentSpeed = isRunning ? runSpeed : speed;
        rb.linearVelocity = new Vector2(move * currentSpeed, rb.linearVelocity.y); // düzeltme: linearVelocity yerine velocity

        // Yüzünü çevir
        if (move > 0 && !isFacingRight)
            Flip();
        else if (move < 0 && isFacingRight)
            Flip();

        // Animasyonlar
        animator.SetFloat("Speed", Mathf.Abs(move));
        animator.SetBool("IsRunning", isRunning);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            animator.SetTrigger("Jump");
        }

        if (Input.GetMouseButtonDown(0) && Time.time > atesZamani)
        {
            animator.SetTrigger("Shoot");
            Fire();
            atesZamani = Time.time + atesSikligi;
        }
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    void Fire()
    {
        if (bulletPrefab == null || atisNoktasi == null) return;

        GameObject bullet = Instantiate(bulletPrefab, atisNoktasi.position, Quaternion.identity);
        Rigidbody2D rbBullet = bullet.GetComponent<Rigidbody2D>();
        if (rbBullet != null)
        {
            Vector2 direction = isFacingRight ? Vector2.right : Vector2.left;
            rbBullet.linearVelocity = direction * bulletSpeed;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            animator.SetBool("IsGrounded", true);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
            animator.SetBool("IsGrounded", false);
        }
    }
}
