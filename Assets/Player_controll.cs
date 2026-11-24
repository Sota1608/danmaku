using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_controll : MonoBehaviour
{
    SpriteRenderer sr;
    Vector3 halfSize;
    Vector3 bottomLeft;
    Vector3 topRight;
    float moveX;
    float moveY;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        halfSize = sr.bounds.extents;
    }

    // Update is called once per frame
    void Update()
    {
        moveX = 0;
        moveY = 0;
        //画面のサイズをワールドの座標に対応付け
        bottomLeft = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 10));
        topRight = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 10));　
        
        //キー処理
        if(Keyboard.current.wKey.isPressed||Keyboard.current.upArrowKey.isPressed)
        {
            moveY = 1.0f;
        }

        if(Keyboard.current.aKey.isPressed||Keyboard.current.leftArrowKey.isPressed)
        {
            moveX = -1.0f;
        }

        if(Keyboard.current.sKey.isPressed||Keyboard.current.downArrowKey.isPressed)
        {
            moveY = -1.0f;
        }

        if(Keyboard.current.dKey.isPressed||Keyboard.current.rightArrowKey.isPressed)
        {
            moveX = 1.0f;
        }


        Vector2 move = new Vector2(moveX, moveY);
        move = move.normalized;

        Vector3 pos = transform.position;
        pos.x += move.x*5.0f*Time.deltaTime;
        pos.x = Mathf.Clamp(pos.x, bottomLeft.x+halfSize.x, topRight.x-halfSize.x);

        pos.y += move.y*5.0f*Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, bottomLeft.y+halfSize.y, topRight.y-halfSize.y);

        transform.position = pos;

    }
}
