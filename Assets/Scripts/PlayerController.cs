using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed = 5f;
    public float projectileSpeed = 10f;
    public float projectileCooldown = 1f;   // How many seconds between shots?
    public int health = 3;
    public AudioClip deathSound;
    public LevelManager levelManager;

    public GameObject projectilePrefab;

    private Transformer transformer;

    private Vector3 size;

    private float lastFired = 0f;

    private bool movingLeft = false;
    private bool movingRight = false;

    void OnTriggerEnter2D(Collider2D collider)
    {
        Projectile projectile = collider.GetComponent<Projectile>();

        if (projectile) {
            health -= projectile.damage;

            if (health <= 0) {
                Die();
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
	    if (Input.GetKey(KeyCode.LeftArrow) || movingLeft) {
            MoveLeft();
        } else if (Input.GetKey(KeyCode.RightArrow) || movingRight) {
            MoveRight();
        }

        if (Input.GetKey(KeyCode.Space)) {
            Fire();
        }
	}

    public void Fire()
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

    public void StartMoveLeft()
    {
        movingLeft = true;
    }

    public void StopMoveLeft()
    {
        movingLeft = false;
    }

    public void StartMoveRight()
    {
        movingRight = true;
    }

    public void StopMoveRight()
    {
        movingRight = false;
    }

    public void MoveRight()
    {
        UpdateShipPosition(speed);
    }

    public void MoveLeft()
    {
        UpdateShipPosition(-1 * speed);
    }

    void UpdateShipPosition(float shift)
    {
        transformer.MoveInXRelativeToTime(shift);
    }

    void Die()
    {
        AudioSource.PlayClipAtPoint(deathSound, transform.position);
        GetComponent<SpriteRenderer>().enabled = false;
        Invoke("Finish", 1.0f);
    }

    void Finish()
    {
        Destroy(gameObject);
        levelManager.LoadLevel("Win Screen");
    }

}
