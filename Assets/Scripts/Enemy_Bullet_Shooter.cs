using UnityEngine;

public class Enemy_Bullet_Shooter : MonoBehaviour
{
    public GameObject BulletPrefab;
    public Transform FirePoint;
    public float interval = 1.0f;
    private float timer = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer >= interval)
        {
            Shoot();
            timer = 0;
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(
            BulletPrefab,
            FirePoint.position,
            Quaternion.identity
        );

        Enemy_Bullet_Controller controller = bullet.GetComponent<Enemy_Bullet_Controller>();
        controller.SetDirection(Vector2.down);
    }
}
