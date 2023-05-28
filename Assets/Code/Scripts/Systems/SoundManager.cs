using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager: MonoBehaviour
{
    [SerializeField] AudioSource MusicAudioSource; //пока выжимаем все из одного аудио ресурса
    [SerializeField] AudioSource SoundAudioSource;
    [SerializeField] AudioClip[] audioClipsSound; //наш набор звуков
    [SerializeField] AudioClip[] audioClipsMusic; //здесь набор музыки

    //**************************************************МУЗЫКА*************************************************
    public void PlaySceneMusic()//пока случайная музыкальная тема
    {
        int CurrentSceneIndex = SceneManager.GetActiveScene().buildIndex; //получаем билдиндекс сцены в переменную
        MusicAudioSource.PlayOneShot(audioClipsMusic[CurrentSceneIndex]); //проигрываем музыку с порядковым номером сцены
    }
    //**************************************************МУЗЫКА*************************************************
    //---------------------------------------------------------------------------------------------------------
    //**************************************************ЗВУКИ**************************************************

    AudioClip LoadClip(NameOfSound name) //метод загрузки ситуационного звука
    {
        string path = "Audio/Sounds/" + name; //путь плюс имя
        AudioClip clip = Resources.Load<AudioClip>(path); //загрузка
        return clip;
    }

    

    public enum NameOfSound
    {
        BrokenGlass,
        FoleyDoorLock,
        WalkOneStep,
        CheckGarbage,
        DogBarking,
        DoorBell,
        ReadingBook,
        ThunderWeather
    }
    //**************************************************ЗВУКИ**************************************************
}
