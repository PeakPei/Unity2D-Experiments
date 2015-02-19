using UnityEngine;

/// <summary>
///   Enemy creature spawner
/// </summary>

public class EnemySpawner : MonoBehaviour {


    /// <summary>
    ///   1 - Designer Variables
    /// </summary>
    public Transform enemyPrefab;

    /// <summary>
    ///   Cooldown in seconds between spawns
    /// </summary>
    public float spawnRate = 2.0f;

    //-------------------------------
    // 2 - Cooldown
    //-------------------------------

    private float spawnCooldown;
    private Vector3 pos;

    void Start() {
        spawnCooldown = 0f;
    }

    void Update() {
        if (spawnCooldown > 0) {
            spawnCooldown -= Time.deltaTime;
        } else {
            Spawn();
        }
    }

    /// <summary>
    ///   Spawn a new enemy if possible
    /// </summary>

    public void Spawn() {
        if (CanSpawn) {
            spawnCooldown = spawnRate;

            //spawn a new enemy
            pos = new Vector3(transform.position.x, transform.position.y + Random.Range(-10.0f,10.0f), transform.position.z);
            
            var enemyTransform = Instantiate(enemyPrefab, pos, Quaternion.identity) as Transform;

        }
    }

    /// <summary>
    ///   Spawner ready to spawn?
    /// </summary>
    public bool CanSpawn {
        get {
            return spawnCooldown <= 0f;
        }
    }
}