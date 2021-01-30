using System;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(DynamicObjectRenderSort))]
public class MovementController : MonoBehaviour
{
    public float COOLDOWN = 0.5f;
    public float MOVE_THRESHOLD = 0.4f;
    public float speed = 1.0f;
    public float cooldownMs = 0.0f;
    public GameObject projectilePrefab;
    public Transform projectileOrigin;
    public int playerHealth = 3;
    public float projectileSpawnDistance = 30.0f;
    public Animator animator;

    private Vector2 lastDirection = Vector2.right;
    private SpriteRenderer spriteRenderer;
    private bool _canInteract;
    internal InteractableComponent interactable;
    public Light2D headLight;
    public bool canInteract { get; set; }
    
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }


    // Update is called once per frame
    void Update()
    {

        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");
        int x = Math.Abs(xAxis) > MOVE_THRESHOLD ? Math.Sign(xAxis) : 0;
        int y = Math.Abs(yAxis) > MOVE_THRESHOLD ? Math.Sign(yAxis) : 0;
        cooldownMs = Mathf.Clamp(cooldownMs - Time.deltaTime, 0.0f, float.MaxValue);
        //Debug.Log("x " + x + "y " + y);
        if (Math.Abs(x) > Math.Abs(y))
        {
            transform.position += new Vector3(x * speed * Time.deltaTime, 0.0f, 0.0f);
            lastDirection = new Vector2(x, 0.0f);
            spriteRenderer.flipX = x >= 0;

        }
        else if (Math.Abs(x) < Math.Abs(y))
        {
            transform.position += new Vector3(0.0f, y * speed * Time.deltaTime, 0.0f);
            lastDirection = new Vector2(0.0f, y);
        }
        animator.SetInteger("x", x);
        animator.SetInteger("y", y);
        animator.SetBool("headless", cooldownMs > 0.0f);
        if (!PauseMenu.isPaused && Input.GetButtonDown("Fire1") && cooldownMs <= 0.0f)
        {
            animator.SetBool("headless", true);
            cooldownMs = COOLDOWN;
            animator.SetTrigger("Shot");
        }

        if (cooldownMs <= 0.0f)
        {
            headLight.enabled = true;
        }

        if (Input.GetButtonDown("Fire2") && canInteract)
        {
            Debug.Log("Maybe interact?");
            interactable.dissolve();
        }
    }

    public void hitPlayer(int damage)
    {
        playerHealth -= damage;
        if (playerHealth <= 0)
        {
            SceneManager.LoadScene("Game Over");
        }
    }

    public void shoot()
    {
        headLight.enabled = cooldownMs == 0.0f;
        GameObject projectile = Instantiate(projectilePrefab, transform.position + (new Vector3(lastDirection.x, lastDirection.y, 0.0f) * projectileSpawnDistance), Quaternion.identity);
        ProjectileController controller = projectile.GetComponent<ProjectileController>();
        controller.direction = lastDirection;
    }
}
