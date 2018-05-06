using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponController : MonoBehaviour {

    public int damage;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Hit");
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Skeleton hit");
            collision.gameObject.GetComponent<EnemyStatsController>().TakeDamage(damage);
        }

    }
}
