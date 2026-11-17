using UnityEngine;
using UnityEngine.InputSystem;

public class Player_shoot : MonoBehaviour
{
    public GameObject [] bulletPrefab;
    float shotInterval = 0.5f;
    float timer = 0f;
    int BulletChange = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        
        //球の切り替え
        if(Keyboard.current.digit1Key.wasPressedThisFrame)
        {
            BulletChange = 0;
        }

        if(Keyboard.current.digit2Key.wasPressedThisFrame)
        {
            BulletChange = 1;
        }

        //球の生成
        if(timer >= shotInterval)
        {
            Instantiate(bulletPrefab[BulletChange], transform.position, Quaternion.identity);
            timer = 0f;
        }
    }
}
