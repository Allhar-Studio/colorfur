using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [Header("Color Indicator")]
    [SerializeField] List<SpriteRenderer> spritesToColor;

    [Header("Bullet")]
    [SerializeField] Color bulletCollor;
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject bulletSpawner;
    [SerializeField] float bulletSpawnTime;

    [Header("Rotation")]
    [SerializeField] GameObject sprites;
    [SerializeField] float rotationSpeed = 3f;
    [SerializeField] float reachArea = 14f;
    [SerializeField] Rigidbody2D rb2d;

    [Header("Shoot")]
    [SerializeField] float shootTime;
    [SerializeField] float shootPrepTime;
    private float lastShotTime;
    private bool isShooting = false;

    private Player player;

    private bool isInRange = false;

    private void Start()
    {
        player = FindObjectOfType<Player>();
        lastShotTime = Time.time;
        rb2d = sprites.GetComponent<Rigidbody2D>();

        if (spritesToColor != null && spritesToColor.Any())
            spritesToColor.ForEach(s => s.color = bulletCollor);
    }

    private void Update()
    {
        isInRange = player != null && Vector2.Distance(player.transform.position, transform.position) < reachArea;

        if (player != null && !isShooting)
        {
            var targetPos = player.transform.position - sprites.transform.position;
            float angle = Mathf.Atan2(targetPos.y, targetPos.x) * Mathf.Rad2Deg;
            rb2d.rotation = Mathf.LerpAngle(rb2d.rotation, angle, rotationSpeed * Time.deltaTime);
        }

        if (Time.time > lastShotTime + bulletSpawnTime && !isShooting && isInRange)
        {
            StartCoroutine(ShootCourotine());
        }
    }

    IEnumerator ShootCourotine()
    {
        isShooting = true;

        yield return new WaitForSeconds(shootPrepTime);

        lastShotTime = Time.time;

        var bulletObj = Instantiate(bullet, bulletSpawner.transform.position, Quaternion.identity);
        IInstatiable instantiable = bulletObj.GetComponent<IInstatiable>();
        if (instantiable != null)
        {
            instantiable.SetUp(sprites.transform.right);
            instantiable.SetUp(bulletCollor);
        }

        DOVirtual.DelayedCall(shootTime, () => { isShooting = false; }, false);
    }
}
