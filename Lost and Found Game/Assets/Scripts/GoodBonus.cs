using UnityEngine;

namespace ProcessNamespace
{
    public sealed class GoodBonus : InteractiveObject
    {
        [SerializeField] private float _healAmount = 1.0f;
        protected override void Interaction()
        {
            /*gameObject.GetComponent<PlayerBase>().TakeHeal(_healAmount);
            Debug.Log(nameof(GoodBonus));*/
        }

        private void Interaction2()
        {
            gameObject.GetComponent<PlayerBase>().TakeHeal(_healAmount);
            Debug.Log(nameof(GoodBonus));
        }
        
        private void OnTriggerEnter(Collider other)
        {
            Interaction2();
            Debug.Log("До уничтожения");
            Destroy(gameObject);
            Debug.Log("После уничтожения");
        }
    }
}