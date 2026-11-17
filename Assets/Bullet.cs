using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 8.0f;
    Vector3 topRight;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame

    void Update()
    {
        topRight = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 10));

        transform.position += Vector3.up * speed * Time.deltaTime;

        //画面外の球を削除
        if(transform.position.y > topRight.y)
        {
            Destroy(gameObject);
        }
    }
}
