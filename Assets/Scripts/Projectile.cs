using UnityEngine;

public class Projectile : MonoBehaviour {

    public int damage = 1;

    public enum ProjectileSource {Player, Enemy };

    public ProjectileSource source;

    public int GetDamage()
    {
        return damage;
    }

    public bool IsOriginPlayer()
    {
        return (source == ProjectileSource.Player);
    }

    public bool IsOriginEnemy()
    {
        return (source == ProjectileSource.Enemy);
    }

    public void Hit()
    {
        Destroy(gameObject);
    }

}
