using System;
using UnityEngine;

namespace ProcessNamespace
{
    public class Shoot : MonoBehaviour
    {
        //[SerializeField] private int damageBullet;
        [SerializeField] private Transform bulletDeparturePointRight;
        [SerializeField] private Transform bulletDeparturePointLeft;
        [SerializeField] private GameObject prefabBullet;
        [SerializeField] private AudioClip audioClipShot;
        [SerializeField] private AudioSource audioSourceShot;

        private void Start()
        {
            audioSourceShot = GetComponent<AudioSource>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                PlaySoundShot();
                float tempInput = Input.GetAxis(AxisManager.HORIZONTAL);
               
                if (tempInput < 0)
                {
                    GameObject projecTille = Instantiate(prefabBullet, bulletDeparturePointLeft.position, bulletDeparturePointLeft.rotation);
                }
                else
                {
                    GameObject projecTille = Instantiate(prefabBullet, bulletDeparturePointRight.position, bulletDeparturePointRight.rotation);
                }
                //projecTille.GetComponent<Bullet>().Damage = damageBullet;
            }
        }

        private void PlaySoundShot()
        {
            audioSourceShot.PlayOneShot(audioClipShot);
        }
    }
}