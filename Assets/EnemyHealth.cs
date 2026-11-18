using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHP = 5;

    private int currentHP;

    void Start()
    {
        currentHP = maxHP;
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;

        Debug.Log("敵のHP：" + currentHP);

        if (currentHP <= 0)
        {
            Debug.Log("敵を撃破しました");
            Destroy(gameObject);
        }
    }
}