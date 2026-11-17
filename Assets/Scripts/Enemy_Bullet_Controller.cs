using UnityEngine;

public class Enemy_Bullet_Controller : MonoBehaviour
{
    Vector3 leftBottom;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float speed = 0.5f;
    private Vector2 direction;

    public void SetDirection(Vector2 dir)
    {
        direction = dir.normalized;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        leftBottom = Camera.main.ViewportToWorldPoint(new Vector3(0,0,10));
        transform.position += (Vector3)
            (direction * speed * Time.deltaTime);

        if (transform.position.y < leftBottom.y)
        {
        Destroy(gameObject);
        }
    }


}
