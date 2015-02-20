using UnityEngine;

/// <summary>
///   Enemy generic behavior
/// </summary>

public class EnemyScript : MonoBehaviour {
    private bool hasSpawn;
    private MoveScript moveScript;
    private WeaponScript[] weapons;


    void Awake() {
        // Retrieve the weapon only once
        weapons = GetComponentsInChildren<WeaponScript>();

        // Retrieve script to disable when not spawn
        moveScript = GetComponent<MoveScript>();
    }

    // 1 - Disbable everything

    void Start() {
        hasSpawn = false;
        collider2D.enabled = false;
        moveScript.enabled = false;
        foreach (WeaponScript weapon in weapons) {
            weapon.enabled = false;
        }
    }


    void Update() {
        
        // 2 - Check if the enemy has spawned.

        if (hasSpawn == false) {
            if (renderer.IsVisibleFrom(Camera.main)) {
                Spawn();
            }
        }

        else {
            // Auto-fire
            foreach (WeaponScript weapon in weapons) {
                if (weapon != null && weapon.CanAttack) {
                    weapon.Attack(true);
                }
            }
            
            // Destroy the object if out of camera

            if (renderer.IsVisibleFrom(Camera.main) == false) {
                Destroy(gameObject);
            }
        }
    }

    // 3 - Activate itself.
    private void Spawn() {
        hasSpawn = true;

        // Enable everything
        collider2D.enabled = true;
        moveScript.enabled = true;
        foreach (WeaponScript weapon in weapons) {
            weapon.enabled = true;
        }
    }
}