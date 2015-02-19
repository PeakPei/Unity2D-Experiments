using UnityEngine;

/// <summary>
///   Enemy generic behavior
/// </summary>

public class EnemyScript : MonoBehaviour {
    private WeaponScript[] weapons;

    void Start() {
        // Destroy(gameObject, 10); // kill off old enemies, this should be a pool
    }

    void Awake() {
        // Retrieve the weapon only once
        weapons = GetComponentsInChildren<WeaponScript>();
    }

    void Update() {
        foreach (WeaponScript weapon in weapons) {
            // Auto-fire
            if (weapon != null && weapon.CanAttack) {
                weapon.Attack(true);
            }
        }
    }
}