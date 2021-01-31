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
    public LifeContainerManager lifeContainer;

    private Vector2 lastDirection = Vector2.right;
    private SpriteRenderer spriteRenderer;
    private bool _canInteract;
    internal InteractableComponent interactable;
    public Light2D headLight;
    public bool canInteract { get; set; }
    public bool canShoot = true;
    
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        lifeContainer.Init(playerHealth, playerHealth);
    }


    // Update is called once per frame
    void Update()
    {

        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");
        int x = Math.Abs(xAxis) > MOVE_THRESHOLD ? Math.Sign(xAxis) : 0;
        int y = Math.Abs(yAxis) > MOVE_THRESHOLD ? Math.Sign(yAxis) : 0;
        cooldownMs = Mathf.Clamp(cooldownMs - Time.deltaTime, 0.0f, float.MaxValue);
        transform.position += new Vector3(x * speed * Time.deltaTime, y * speed * Time.deltaTime, 0.0f);
        Vector2 curDir = new Vector2(x, y);
        lastDirection = curDir != Vector2.zero ? curDir : lastDirection;
        spriteRenderer.flipX = x >= 0;

        //Debug.Log("x " + x + "y " + y);

        animator.SetInteger("x", x);
        animator.SetInteger("y", y);
        animator.SetBool("headless", cooldownMs > 0.0f);
        if (!PauseMenu.isPaused && Input.GetButtonDown("Fire1") && cooldownMs <= 0.0f && canShoot)
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
            // Maybe interact?
            interactable.Dissolve();
        }
    }

    public void hitPlayer(int damage)
    {
        playerHealth -= damage;
        lifeContainer.SetCurrentLife(playerHealth);
        if (playerHealth <= 0)
        {
            SceneManager.LoadScene("03_Game_over");
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
