using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Defines the damage and defines whether the projectile belongs to the ‘Enemy’ or to the ‘Player’, whether the projectile is destroyed in the collision, or not and amount of damage.
/// </summary>

public class Projectile : MonoBehaviour {

    [Tooltip("Damage which a projectile deals to another object. Integer")]
    public float damage;

    [Tooltip("Whether the projectile belongs to the ‘Enemy’ or to the ‘Player’")]
    public bool enemyBullet;

    [Tooltip("Whether the projectile is destroyed in the collision, or not")]
    public bool destroyedByCollision;

    public Transform parent;

    public void SetDamage(float damage)
	{
        this.damage = damage;
	}

    private void OnTriggerEnter2D(Collider2D collision) //when a projectile collides with another object
    {
        if ((collision.transform.parent != this.parent && collision.tag == "Shield") || (collision.tag == "Player" && collision.transform != this.parent))
		{
            Player otherPlayer = collision.GetComponent<Player>();
            
            if (collision.tag == "Shield")
			{
                otherPlayer = collision.transform.parent.GetComponent<Player>();
            }

            if (otherPlayer != null)
            {
                otherPlayer.GetDamage(damage);
            }

            if (destroyedByCollision)
                Destruction();
		}
    }

    public void SetParent(Transform transform)
	{
        parent = transform;
	}

    void Destruction() 
    {
        Destroy(gameObject);
    }
}