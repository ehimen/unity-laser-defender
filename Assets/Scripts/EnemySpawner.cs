using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject enemyPrefab;

    public float width = 10f;
    public float height = 5f;
    public float speed = 5f;
    public float spawnDelay = 0.25f;

    private float direction = 1f;
    private Transformer transformer;
    
	void Start ()
    {
        SpawnUntilFull();
        transformer = new Transformer(Camera.main, transform, new Vector3(width, height));
	}

    void Update()
    {
        if (transformer.MoveInXRelativeToTime(speed * direction)) {
            direction *= -1f;
        }

        if (AllMembersAreDead()) {
            SpawnUntilFull();
        }
    }


    void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(width, height));
    }

    void SpawnEnemies()
    {
        foreach (Transform child in transform)
        {
            GameObject enemy = Instantiate(enemyPrefab, child.position, Quaternion.identity) as GameObject;

            // Set the position as the created enemy's parent.
            enemy.transform.parent = child;
        }
    }

    void SpawnUntilFull()
    {
        GameObject nextPosition = NextFreePosition();

        if (nextPosition) {
            GameObject enemy = Instantiate(enemyPrefab, nextPosition.transform.position, Quaternion.identity) as GameObject;

            // Set the position as the created enemy's parent.
            enemy.transform.parent = nextPosition.transform;
        }

        if (NextFreePosition()) {
            // Only call ourselves again if we have something to spawn.
            Invoke("SpawnUntilFull", spawnDelay);
        }
    }

    bool AllMembersAreDead()
    {
        foreach (Transform position in transform) {
            if (position.childCount > 0) {
                return false;
            }
        }

        return true;
    }

    GameObject NextFreePosition()
    {
        foreach (Transform position in transform) {
            if (position.childCount == 0) {
                return position.gameObject;
            }
        }

        return null;
    }

}
