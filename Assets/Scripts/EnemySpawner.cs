using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject enemyPrefab;

    public float width = 10f;
    public float height = 5f;

    public float speed = 5f;

    private float direction = 1f;
    private Transformer transformer;
    
	void Start ()
    {
        SpawnEnemies();
        transformer = new Transformer(Camera.main, transform, new Vector3(width, height));
	}

    void Update()
    {
        if (transformer.MoveInXRelativeToTime(speed * direction)) {
            direction *= -1f;
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

}
