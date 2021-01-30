using UnityEngine;

namespace ProcessNamespace
{
    public class IgnoreEnemyCollision : BonusBase
    {
        [SerializeField] private float _effectTime;

        private float _effectTimer;
        

        private int _playerLayerMask = 9; // слой игрока
        private int _enemiesLayerMask = 10; // слой врагов

        protected override void ActivateEffect(GameObject player)
        {
            base.ActivateEffect(player);
            Physics.IgnoreLayerCollision(_playerLayerMask, _enemiesLayerMask, true); //непосредственно активация игнора коллизий
            
            _effectTimer = _effectTime;
        }

        private void LateUpdate()
        {
            _effectTimer -= Time.deltaTime;

            if (_effectTimer <= 0)
            {
                Physics.IgnoreLayerCollision(_playerLayerMask, _enemiesLayerMask, false); //непосредственно деактивация игнора коллизий
            }
        }
    }
}