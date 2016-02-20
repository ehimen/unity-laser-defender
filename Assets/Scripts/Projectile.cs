using UnityEngine;

public class Projectile : MonoBehaviour {

    public int damage = 1;

    public int GetDamage()
    {
        return damage;
    }

    public void Hit()
    {
        Destroy(gameObject);
    }

}
