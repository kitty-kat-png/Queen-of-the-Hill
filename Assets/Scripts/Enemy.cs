using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected float health;
    [SerializeField] protected float recoilLength;
    [SerializeField] protected float recoilFactor;
    [SerializeField] protected bool isRecoiling = false;

    [SerializeField] protected PlayerController player;
    [SerializeField] protected float speed;

    protected float recoilTimer;
    protected Rigidbody2D rb;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        
    }

    protected void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        player = PlayerController.Instance;
    }
    // Update is called once per frame
    protected virtual void Update()
    {
       if (health <= 0)
        {
            Destroy(gameObject);
        }
       if(isRecoiling)
        {
            if (recoilTimer < recoilLength)
            {
                recoilTimer += Time.deltaTime;
            }
            else
            {
                isRecoiling = false;
                recoilTimer = 0;
            }
        }
    }
    public virtual void EnemyHit(float _damangeDone, Vector2 _hitDirection, float _hitForce)
    {
        health -= _damangeDone;
        if(!isRecoiling)
        {
            rb.AddForce(-_hitForce * recoilFactor * _hitDirection);
        }
    }
}
