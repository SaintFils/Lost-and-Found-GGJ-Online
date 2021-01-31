using UnityEngine;

namespace ProcessNamespace
{
    public class Bullet : MonoBehaviour
    {
        //private float damage = 50;
        [SerializeField] private float speedBullet = 50.0f;
        [SerializeField] private float lifeTime = 0.3f;

        private Rigidbody bulletRigitBody;

        //public int Damage { get => damage; set => damage = value; }

        private void Start()
        {
            Destroy(gameObject, lifeTime);

            bulletRigitBody = gameObject.GetComponent<Rigidbody>();

            Vector3 impulce = transform.right * bulletRigitBody.mass * speedBullet;

            bulletRigitBody.AddForce(impulce, ForceMode.Impulse);
        }

        /*private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                other.gameObject.GetComponent<Enemy>()?.GetDamage(damage);
                Destroy(gameObject);
            }

            if (other.gameObject.CompareTag("Wall"))
            {
                Destroy(gameObject);
            }

            if (other.TryGetComponent<PlayerHealth>(out PlayerHealth playerHealth))
            {
                playerHealth.GetDamage(damage);
                Destroy(gameObject);
            }
        }*/
    }
}