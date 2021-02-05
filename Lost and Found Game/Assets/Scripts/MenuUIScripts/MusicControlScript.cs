using UnityEngine;
using UnityEngine.UI;


//Скрип для управления громкостью музыки и прочих звуков
public class MusicControlScript : MonoBehaviour
{
    [SerializeField] private Slider Musics_Slider;// Подключаем слайдер Музыки и получаем его значения
    [SerializeField] private Slider Sound_Slider;
    [SerializeField] private AudioSource Music;// Подключаем саму музыку
    [SerializeField] private AudioSource Sound;

    private void Start()
    {
        Musics_Slider.value = PlayerPrefs.GetFloat("Music",Musics_Slider.value); // Получаем сохраненные значения слайдера музыки

        Sound_Slider.value = PlayerPrefs.GetFloat("Sound", Sound_Slider.value);
    }

    private void Update()
    {
        Music.volume = Musics_Slider.value; //Изменяем Громкость музыки в зависимости от значении слайдера Музыки

        Sound.volume = Musics_Slider.value;


        PlayerPrefs.SetFloat("Music",Musics_Slider.value); // Сохраняем значеине слайдера Музыки

        PlayerPrefs.SetFloat("Sound", Sound_Slider.value);
    }

}
