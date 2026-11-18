using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float speed = 2f;

    // 弾のダメージ
    public int damage = 1;

    void Update()
    {
        // 弾を上方向に動かす
        transform.position += Vector3.up * speed * Time.deltaTime;
    }

    // 他のCollider2Dに触れたとき
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("何かに当たりました");

        // Enemyに当たったか確認
        if (collision.CompareTag("Enemy"))
        {
            Debug.Log("Enemyに当たりました");

            // EnemyHealthを取得
            EnemyHealth enemyHealth = collision.GetComponent<EnemyHealth>();

            if (enemyHealth != null)
            {
                Debug.Log("EnemyHealthを取得しました");

                // 敵にダメージを与える
                enemyHealth.TakeDamage(damage);
            }

            // 敵に当たった弾を消す
            Destroy(gameObject);
        }
    }
}