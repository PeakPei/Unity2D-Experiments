using UnityEngine;

/// <summary>
///   Launch projectile
/// </summary>

public class WeaponScript : MonoBehaviour {
    //-------------------------------
    // 1 - Designer Variables
    //-------------------------------

    /// <summary>
    ///   Projectile prefab for shooting
    /// </summary>
    public Transform shotPrefab;

    /// <summary>
    ///   Cooldown in seconds between shots
    /// </summary>
    public float shootingRate = 0.25f;

    //-------------------------------
    // 2 - Cooldown
    //-------------------------------

    private float shotCooldown;

    void Start() {
        shotCooldown = 0f;
    }

    void Update() {
        if (shotCooldown > 0) {
            shotCooldown -= Time.deltaTime;
        }
    }

    //-------------------------------
    // 3 - Shooting from another script
    //-------------------------------

    /// <summary>
    ///   Create a new projectile if possible
    /// </summary>
    public void Attack(bool isEnemy) {
        if (CanAttack) {
            shotCooldown = shootingRate;

            //Create a new shot
            var shotTransform = Instantiate(shotPrefab) as Transform;

            // Assign position
            shotTransform.position = transform.position;

            // The is enemy property
            ShotScript shot = shotTransform.gameObject.GetComponent<ShotScript>();
            if (shot != null) {
                shot.isEnemyShot = isEnemy;
            }

            // Make the weapon shot always towards it
            MoveScript move = shotTransform.gameObject.GetComponent<MoveScript>();
            if (move != null) {
                move.direction = this.transform.right;
            }
        }
    }

    /// <summary>
    ///   Is the weapon ready to create a new projectile?
    /// </summary>
    public bool CanAttack {
        get {
            return shotCooldown <= 0f;
        }
    }
}