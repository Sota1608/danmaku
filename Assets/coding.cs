using UnityEngine;

public class coding : MonoBehaviour
{
    public float moveSpeed = 5f;

    // プレイヤーの最大HP
    public int maxHP = 10;

    // 現在のHP
    private int currentHP;

    void Start()
    {
        // ゲーム開始時にHPを最大値にする
        currentHP = maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        //キーボード入力を取得
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        //移動方向を作成
        Vector3 moveDirection = new Vector3(horizontal, vertical, 0f);

        //自機を移動させる
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }

    // ダメージを受けたとき
    public void TakeDamage(int damage)
    {
        currentHP -= damage;

        Debug.Log("プレイヤーのHP：" + currentHP);

        // HPが0以下になったら
        if (currentHP <= 0)
        {
            Debug.Log("プレイヤーが撃破されました");

            // 今はテストとしてプレイヤーを消す
            Destroy(gameObject);
        }
    }
}