using System;
using UnityEngine;

[RequireComponent(typeof(DynamicObjectRenderSort))]
public class MovementController : MonoBehaviour
{
    public float COOLDOWN = 0.5f;
    public float MOVE_THRESHOLD = 0.4f;
    public float speed = 1.0f;
    public float cooldownMs = 0.0f;
    public GameObject projectilePrefab;
    public Transform projectileOrigin;
    public float projectileSpawnDistance = 30.0f;
    private Vector2 lastDirection = Vector2.right;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
    }


    // Update is called once per frame
    void Update()
    {

        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");
        int x = Math.Abs(xAxis) > MOVE_THRESHOLD ? Math.Sign(xAxis) : 0;
        int y = Math.Abs(yAxis) > MOVE_THRESHOLD ? Math.Sign(yAxis) : 0;
        Vector2 direction = new Vector2(x, y);
        lastDirection = direction != Vector2.zero ? direction : lastDirection;
        cooldownMs = Mathf.Clamp(cooldownMs - Time.deltaTime, 0.0f, float.MaxValue);

        //Debug.Log("x " + x + "y " + y);
        if (Math.Abs(x) > Math.Abs(y))
        {
            transform.position += new Vector3(x * speed * Time.deltaTime, 0.0f, 0.0f);
        } else
        {
            transform.position += new Vector3(0.0f, y * speed * Time.deltaTime, 0.0f);
        }
        if (Input.GetAxis("Fire1") > 0 && cooldownMs <= 0.0f)
        {
            cooldownMs = COOLDOWN;
            animator.SetTrigger("Shot");
            GameObject projectile = Instantiate(projectilePrefab, transform.position + (new Vector3(lastDirection.x, lastDirection.y, 0.0f) * projectileSpawnDistance) , Quaternion.identity);
            ProjectileController controller = projectile.GetComponent<ProjectileController>();
            controller.direction = lastDirection;
        }
    }
}
