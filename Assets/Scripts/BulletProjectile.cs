
using UnityEngine;

public class BulletProjectile : MonoBehaviour
{
    private Vector3 targetPosition;

    public void Setup(Vector3 targetPosition)
    {
        this.targetPosition = targetPosition;
    }
    private void Update()
    {
        Vector3 movDir = (targetPosition - transform.position).normalized;
        float moveSpeed = 20f;
        movDir.z = 0;
        transform.position += movDir * moveSpeed * Time.deltaTime;

        if (Mathf.Abs(transform.position.x) >= 9f || Mathf.Abs(transform.position.y) >= 7f)

        {
            Destorying();
        }
    }

    private void Destorying()
    {
        Destroy(gameObject);
    }



}
