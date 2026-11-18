using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 3f;

    // 敵弾のダメージ
    public int damage = 1;

    void Update()
    {
        // 弾を下方向に動かす
        transform.position += Vector3.down * speed * Time.deltaTime;
    }

    // 他のCollider2Dに触れたとき
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("敵弾が何かに当たりました");

        // Playerに当たったか確認
        if (collision.CompareTag("Player"))
        {
            Debug.Log("敵弾がPlayerに当たりました");

            // codingを取得
            coding player = collision.GetComponent<coding>();

            if (player != null)
            {
                Debug.Log("Playerのcodingを取得しました");

                // プレイヤーにダメージを与える
                player.TakeDamage(damage);
            }

            // プレイヤーに当たった敵弾を消す
            Destroy(gameObject);
        }
    }
}