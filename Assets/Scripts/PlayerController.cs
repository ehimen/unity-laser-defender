using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed = 5f;
    public float projectileSpeed = 10f;
    public float projectileCooldown = 1f;   // How many seconds between shots?
    public int health = 3;

    public GameObject projectilePrefab;

    private Transformer transformer;

    private Vector3 size;

    private float lastFired = 0f;

    void OnTriggerEnter2D(Collider2D collider)
    {
        Projectile projectile = collider.GetComponent<Projectile>();

        if (projectile) {
            health -= projectile.damage;

            if (health <= 0) {
                Destroy(gameObject);
            }

            projectile.Hit();
        }
    }

    void Start()
    {
        size = gameObject.GetComponent<SpriteRenderer>().sprite.bounds.size;
        transformer = new Transformer(Camera.main, transform, size);
    }
	
	void Update ()
    {
	    if (Input.GetKey(KeyCode.LeftArrow)) {
            MoveLeft();
        } else if (Input.GetKey(KeyCode.RightArrow)) {
            MoveRight();
        }

        if (Input.GetKey(KeyCode.Space)) {
            Fire();
        }
	}

    void Fire()
    {
        bool fired = ProjectileFactory.CreateProjectile(
            transform.position + (Vector3.up * size.y * 0.5f),
            Vector3.up * projectileSpeed,
            projectilePrefab,
            lastFired,
            projectileCooldown
        );

        if (fired) {
            lastFired = Time.time;
        }
    }


    void MoveRight()
    {
        UpdateShipPosition(speed);
    }

    void MoveLeft()
    {
        UpdateShipPosition(-1 * speed);
    }

    void UpdateShipPosition(float shift)
    {
        transformer.MoveInXRelativeToTime(shift);
    }

}
