using UnityEngine;

class ProjectileFactory
{

    public static bool CreateProjectile(Vector3 position, Vector3 velocity, GameObject prefab, float lastFired, float cooldown)
    {
        if ((lastFired > 0) && ((Time.time - lastFired) <= cooldown)) {
            return false;
        }

        GameObject projectile = Object.Instantiate(prefab, Vector3.zero, Quaternion.identity) as GameObject;

        projectile.transform.position = position;

        projectile.GetComponent<Rigidbody2D>().velocity = velocity;

        return true;
    }

}