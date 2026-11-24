using NUnit.Framework;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class Player_shoot : MonoBehaviour
{
    public GameObject [] bulletPrefab;
    float shotInterval = 0.5f;
    float snipeInterval = 1.4f;
    float currentInterval = 0.5f;
    float timer = 0f;
    int BulletChange = 0;
    int lastBulletChange = -1;
    bool hasshot = false;
    bool isCharging = false;
    bool chargeJustShot = false;
    float chargeTime = 0f;
    float maxChargeTime = 1.8f;
    float minSize = 0.3f;
    float maxSize = 1.2f;
    GameObject NormalBullet;
    GameObject chargingBullet;
    GameObject SnipeBullet;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        //球の切り替え
        if(!isCharging)
        {
            if(Keyboard.current.digit1Key.wasPressedThisFrame)
            {
                BulletChange = 0;   //通常弾

                if(chargeJustShot)
                {
                    currentInterval = shotInterval;
                }
            }

            if(Keyboard.current.digit2Key.wasPressedThisFrame)
            {
                BulletChange = 1;   //チャージ弾
            }

            if(Keyboard.current.digit3Key.wasPressedThisFrame)
            {
                BulletChange = 2;   //スナイプ弾

                if(chargeJustShot)
                {
                    currentInterval = snipeInterval;
                }
            }
        }


        //経過時間
        if(hasshot)
        {
            timer += Time.deltaTime;
        }


        //通常弾の生成
        if(BulletChange == 0 && Keyboard.current.spaceKey.isPressed)
        {
            if(!hasshot || timer >= currentInterval)
            {
                NormalBullet = Instantiate(bulletPrefab[BulletChange], transform.position, Quaternion.identity);
                NormalBullet.GetComponent<Bullet>().Launch();
                lastBulletChange = 0;
                hasshot = true;
                chargeJustShot = false;

                currentInterval = shotInterval;
                timer = 0f;
            }
        }     
        

        //チャージ開始
        if(BulletChange == 1 && Keyboard.current.spaceKey.isPressed && (!isCharging) && (!hasshot || lastBulletChange == 1 || timer >= currentInterval))
        {
            isCharging = true;
            chargeTime = 0f;

            chargingBullet = Instantiate(bulletPrefab[BulletChange], transform.position + Vector3.up, Quaternion.identity);
            chargingBullet.GetComponent<Bullet>().StartCharging();
        }

        //チャージ中
        if(isCharging && Keyboard.current.spaceKey.isPressed)
        {
            chargingBullet.transform.position = transform.position + Vector3.up;
            chargeTime = Mathf.Min(chargeTime + Time.deltaTime, maxChargeTime);

            float chargeRate = chargeTime / maxChargeTime;
            chargingBullet.GetComponent<Bullet>().UpdateChargingEffect(chargeRate);
            float bulletSize = Mathf.Lerp(minSize, maxSize, chargeRate);

            chargingBullet.transform.localScale = Vector3.one * bulletSize;
        }

        //チャージ弾発射
        if(isCharging && Keyboard.current.spaceKey.wasReleasedThisFrame)
        {
            chargingBullet.GetComponent<Bullet>().Launch();
            lastBulletChange = 1;
            isCharging = false;
            hasshot = true;
            chargeJustShot = true;
            timer = 0f;
        }


        //スナイプ弾の生成
        if(BulletChange == 2 && Keyboard.current.spaceKey.isPressed)
        {
            if(!hasshot || timer >= currentInterval)
            {
                SnipeBullet = Instantiate(bulletPrefab[BulletChange], transform.position, Quaternion.identity);
                SnipeBullet.GetComponent<Bullet>().Launch();
                lastBulletChange = 2;
                hasshot = true;
                chargeJustShot = false;

                currentInterval = snipeInterval;
                timer = 0f;
            }
        }
    }
}
