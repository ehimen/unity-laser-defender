using UnityEngine;

public class Enemy : MonoBehaviour {

    public int health = 2;

    public GameObject projectilePrefab;

    public float projectileSpeed = 10f;

    public float projectileCooldown = 0.2f;

    public float aggressiveness = 0.1f;

    private int currentHealth;

    private float lastFired = 0f;

    void Start()
    {
        currentHealth = health;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        Projectile projectile = collider.gameObject.GetComponent<Projectile>();

        if (projectile) {

            currentHealth -= projectile.GetDamage();

            if (currentHealth <= 0) {
                Destroy(gameObject);
            }

            projectile.Hit();

        }
    }

    void Update()
    {
        Fire();
    }

    void Fire()
    {
        // Normalise aggressiveness based on time taken to render last frame.
        // Also, a constant to bring aggressiveness to reasonable values (0 = passive, 1 = fire always).
        if (Random.value >= (aggressiveness * Time.deltaTime)) {
            return;
        }

        Vector3 size = gameObject.GetComponent<SpriteRenderer>().sprite.bounds.size;

        bool fired = ProjectileFactory.CreateProjectile(
            transform.position + (Vector3.down * size.y * 0.5f),
            Vector3.down * projectileSpeed,
            projectilePrefab,
            lastFired,
            projectileCooldown
        );

        if (fired) {
            lastFired = Time.time;
        }
    }

}
