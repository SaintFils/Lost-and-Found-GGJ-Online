using UnityEngine;

//Скрипт Чекпоинтов
public class CheckPoints : MonoBehaviour
{
   [SerializeField] private Transform _player;
   [SerializeField] private Transform[] _checkpointsPos;
    
   [SerializeField]private int _checkPointsValue;

    private void Start()
    { 
        _checkPointsValue = PlayerPrefs.GetInt("Point",_checkPointsValue);
        Debug.Log(_checkPointsValue);
        for (int i = 0; i < _checkpointsPos.Length; i++)
        {
            if (_checkPointsValue == i)
            {
                _player.position = _checkpointsPos[i].position;
            }
        }

    }

    private void Update()
    {
        PlayerPrefs.SetInt("Point", _checkPointsValue);
        Debug.Log(_checkPointsValue);
    }



    private void OnTriggerEnter(Collider other)
    {
        for (int i = 0; i < _checkpointsPos.Length; i++)
        {
            if (other.gameObject.CompareTag($"CheckPoint {i}"))
            {
                _checkPointsValue = i;
            }
        }

    }
}
