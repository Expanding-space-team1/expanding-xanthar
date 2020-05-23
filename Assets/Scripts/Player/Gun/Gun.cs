using System;
using System.Collections;
using PlayerData;
using UnityEngine;

public class Gun : MonoBehaviour
{ 
    // Input fields

    [SerializeField] protected float damage;

    [SerializeField] private bool isProjectile;

    [SerializeField]
    protected float range;

    [SerializeField] protected float accuracyShotDecrease;

    [SerializeField] protected float fireRate; // Bullets / sec
    [SerializeField] protected FireType fireType;

    [SerializeField] protected GameObject muzzleGameObject;

    [SerializeField] protected AudioClip gunShotClip;

    [SerializeField] protected Corsair corsair;

    [SerializeField] protected Player player;
    [SerializeField] private GameObject _bulletLocation;

    protected AudioSource audioSource;


    [Header("Bullet Line")]
    [SerializeField]
    private LineRenderer lineRenderer;

    [Header("Projectile")]
    [SerializeField]
    private GameObject _projectilePrefab;


    /*
     * Vars for full auto 
     */
    private bool triggerPulled = false;
    private bool waitForShot;

    // Start is called before the first frame update
    void Start()
    {
        if (gunShotClip == null) Debug.LogWarning("Gun has no audio");
        
        audioSource = GetComponent<AudioSource>();
        
        if (muzzleGameObject != null) muzzleGameObject.SetActive(false);
        InputManager.inputAction += HandleTrigger;
    }

    // Update is called once per frame
    void Update()
    {
        if (triggerPulled && !waitForShot)
        {

            SpawnBullet();
        }
    }

    void OnDisable()
    {
        StopAllCoroutines();
        waitForShot = false;
        if (muzzleGameObject != null) muzzleGameObject.SetActive(false);
        lineRenderer.enabled = false; // Probably fixed bug [1.1]
    }

    private void SpawnBullet()
    {
        if (audioSource == null) return; // User is dead

        if (gunShotClip != null)audioSource.PlayOneShot(gunShotClip);
        
        StartCoroutine(FireCooldown());
        
        if (muzzleGameObject != null) StartCoroutine(Flash());

        if (isProjectile)
        {
            if (_projectilePrefab == null)
            {
                Debug.LogWarning("Gun has no projectile prefab");
                return;
            }
            
            corsair.EffectCorsair(accuracyShotDecrease);
            
            // Shoot projectile
            var position = _bulletLocation.transform.position;
            var projectileObject = Instantiate(_projectilePrefab.gameObject, position, Quaternion.identity);

            var direction = corsair.RandomBulletDirection();

            direction.Normalize();
                
            var projectile = projectileObject.GetComponent<Projectile>();
            
            projectile._direction = direction;
            projectile._damage = damage;
        }
        else
        {
            if (lineRenderer == null)
            {
                Debug.LogWarning("Gun has no LineRenderer");
                return;
            }
            
            corsair.EffectCorsair(accuracyShotDecrease);
            
            // Shoot ray
            StartCoroutine(InitBulletRay());
        }
    }

    private void HitCollider(Vector2 position)
    {
        EffectManager.GetInstance().Play(EffectManager.EffectType.EXPLOSION, position);
    }

    private IEnumerator FireCooldown()
    {
        waitForShot = true;
        yield return new WaitForSeconds(1f / fireRate);
        waitForShot = false;
    }

    private IEnumerator Flash()
    {
        muzzleGameObject.SetActive(true);
        yield return new WaitForSeconds(.01f);
        muzzleGameObject.SetActive(false);
    }
    
    private IEnumerator InitBulletRay()
    {
        Vector2 beginPos = new Vector2(corsair.transform.position.x, corsair.transform.position.y);

        Vector2 direction = corsair.RandomBulletDirection();

        direction.Normalize();

        int layerMask = 1 << 8; //layer 8 is Player Layer
        // This would cast rays only against colliders in layer 8.
        // But instead we want to collide against everything except layer 8.
        //The ~ operator does this, it inverts a bitmask.
        layerMask = ~layerMask;

        RaycastHit2D raycastHit = Physics2D.Raycast(beginPos, direction, range, layerMask);

        lineRenderer.SetPosition(0, beginPos);

        Vector2 endPosition;

        bool isHit = raycastHit.collider != null;

        if (!isHit)
        {
            endPosition = beginPos + direction * range;
        }
        else
        {
            endPosition = raycastHit.point;

            HitCollider(endPosition);
        }


        lineRenderer.SetPosition(1, endPosition);

        lineRenderer.enabled = true;

        yield return new WaitForSeconds(0.05f);

        lineRenderer.enabled = false;
    }

    public void HandleTrigger(InputManager.InputType inputType, float value)
    {
//        if (!gameObject.activeSelf) return;

        if (player == null)
        {
            Debug.LogWarning("Player has not been set! Check the inspector.");
            return;
        }
        

        if (!player.isActiveAndEnabled) return;

        if (inputType == InputManager.InputType.FIRE)
        {

            if (fireType == FireType.FULL)
            {
                triggerPulled = value > 0;
            }
            else if (fireType == FireType.SEMI && value > 0 && !waitForShot)
            {
                SpawnBullet();
            }

        } else if (inputType == InputManager.InputType.FIRE_2)
        {

            corsair.aiming = value > 0;
        }
    }

    public enum FireType
    {
        FULL, SEMI
    }
    
    
}
