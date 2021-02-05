using UnityEngine;


namespace ProcessNamespace
{
    public class BonusBase : MonoBehaviour //скрипт вешается на пустой родительский геймобъект, коллайдер с тригером вешать именно на него
    {
        [SerializeField] private bool _canRespawn;
        [SerializeField] private float _respawnTime;
        [SerializeField] private GameObject _visualisation; //дочерний объект, который содержит модельку
        [SerializeField] private DoubleJumpBonus _doubleJump;

        private float _respawnTimer;
        private bool _isActiveNow = true;

        private void OnTriggerEnter(Collider other)
        {
            if (_isActiveNow)
            {
                if (other.GetComponent<PlayerInput>() != null) //заменить Moveable на что-нибудь, что есть только у игрока, например PlayerInput
                {
                    _isActiveNow = false;
                    _visualisation.SetActive(false);
                    _respawnTimer = _respawnTime;
                    ActivateEffect(other.gameObject);
                }
                else if (other.gameObject.CompareTag("doubleJump"))
                {
                    _doubleJump._dobleJumpEarned = true;
                    _respawnTimer = _respawnTime;
                    ActivateEffect(other.gameObject);
                    _isActiveNow = false;
                }
            }
        }


        private void Update()
        {
            if (_canRespawn && !_isActiveNow) // если бонус нельзя зареспавнить, то он не появится, в ином случае тикает таймер, после которого объект снова станет активированным
            {
                _respawnTimer -= Time.deltaTime;

                if (_respawnTimer <= 0)
                {
                    _isActiveNow = true;
                    _visualisation.SetActive(true);
                }
            }
        }

        protected virtual void ActivateEffect(GameObject player) //наследованием менять реализации в зависимости от самого бонуса
        {
        }
    }
}