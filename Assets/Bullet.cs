using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 8.0f;
    Vector3 topRight;
    bool isLaunched = false;
    ParticleSystem chargeEffect;
    ParticleSystem auraEffect;
    
    public void Launch()
    {
        isLaunched = true;
    }

    public void StartCharging()
    {
        if(chargeEffect != null)
        {
            chargeEffect.Play();
        }

        if(auraEffect != null)
        {
            auraEffect.Play();
        }
    }

    public void UpdateChargingEffect(float chargeRate)
    {
        if(chargeEffect != null)
        {
            var emission = chargeEffect.emission;
            emission.rateOverTime = Mathf.Lerp(4f, 16f, chargeRate);
        }

        var main = chargeEffect.main;
        main.startSize = Mathf.Lerp(0.06f, 0.10f, chargeRate);
        main.startColor = Color.Lerp(new Color(0.65f, 0.45f, 1f, 0.7f), new Color(0.8f, 0.7f, 1f, 1f), chargeRate);

        if(chargeRate >= 1)
        {
            if(auraEffect != null && !auraEffect.isPlaying)
            {
                auraEffect.Play();
            }
        }
        else
        {
            if(auraEffect != null && auraEffect.isPlaying)
            {
                auraEffect.Stop();
            }
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        Transform chargeTransform = transform.Find("Charge_Effect");
        Transform auraTransform = transform.Find("Aura_Effect");

        if(chargeTransform != null)
        {
            chargeEffect = transform.Find("Charge_Effect").GetComponent<ParticleSystem>();
        }

        if(auraTransform != null)
        {
            auraEffect = transform.Find("Aura_Effect").GetComponent<ParticleSystem>();
        }
    }

    // Update is called once per frame

    void Update()
    {
        topRight = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 10));

        if(isLaunched)
        {
            //球が上へ移動
            transform.position += Vector3.up * speed * Time.deltaTime;

            //画面外の球を削除
            if(transform.position.y > topRight.y)
            {
                Destroy(gameObject);
            }
        }
    }
}
