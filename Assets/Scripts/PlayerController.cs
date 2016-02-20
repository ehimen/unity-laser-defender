using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float speed = 5f;
    public float projectileSpeed = 10f;
    public float projectileCooldown = 1f;   // How many seconds between shots?

    public GameObject projectilePrefab;

    private Transformer transformer;

    private Vector3 size;

    private float lastFired = 0f;

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
        if ((lastFired > 0) && ((Time.time - lastFired) <= projectileCooldown)) {
            return;
        }

        GameObject projectile = Instantiate(projectilePrefab, Vector3.zero, Quaternion.identity) as GameObject;
        // Put the laser at the top of the ship.
        projectile.transform.position = transform.position + (Vector3.up * size.x * 0.5f);

        projectile.GetComponent<Rigidbody2D>().velocity = Vector3.up * projectileSpeed;

        lastFired = Time.time;
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
