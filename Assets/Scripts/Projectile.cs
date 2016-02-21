using UnityEngine;

public class Projectile : MonoBehaviour {

    public int damage = 1;

    public AudioClip collisionSound;

    public int GetDamage()
    {
        return damage;
    }

    public void Hit()
    {
        Destroy(gameObject);
        MakeCollisionSound();
    }

    void MakeCollisionSound()
    {
        AudioSource.PlayClipAtPoint(collisionSound, transform.position);
    }

}
