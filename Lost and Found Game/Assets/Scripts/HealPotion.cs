using UnityEngine;

namespace ProcessNamespace
{
    public class HealPotion : BonusBase
    {
        [SerializeField] private float healAmount = 1.0f;

        protected override void ActivateEffect(GameObject player)
        {
           base.ActivateEffect(player);
          // Debug.Log(player.gameObject.GetComponent<Destructable>()._currentHealthPoint);
           player.GetComponent<Destructable>()?.ApplyHeal(healAmount);            
          // Debug.Log($"{player.gameObject.GetComponent<Destructable>()._currentHealthPoint} after heal");
            //Destroy(gameObject);
        }
    }
}