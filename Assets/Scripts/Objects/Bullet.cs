
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform player;
    [SerializeField] private Transform pfBullet;
    private Camera mainCamera;

    private void Awake()
    {
        player = GetComponent<Transform>();
        mainCamera = Camera.main;
    }

    void Update()
    {

        if (Input.GetMouseButtonDown(1))
        {
            Transform bullet = Instantiate(pfBullet, transform.position, Quaternion.identity);
            bullet.GetComponent<BulletProjectile>().Setup(mainCamera.ScreenToWorldPoint(Input.mousePosition));

        }

    }

}
