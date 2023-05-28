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

    public void PlaySituationSound(AudioClip situation)//метод проигрывающий выбранный ситуационный клип через аудио источник для звуков
    {
        SoundAudioSource.PlayOneShot(situation);
    }

    public AudioClip LoadClip(NameOfSound name) //метод загрузки ситуационного звука
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
        ThunderWeather,
        PlasticBag
    }
    //**************************************************ЗВУКИ*************************************************
    //---------------------------------------------------------------------------------------------------------
    //**********************************************СТАРЫЙ СВИТЧ**********************************************
    public void OldSituationSound(NameOfSound situation)//Ситуационный звук проигрываем через этого метод. Что бы не путаться, пишем в него тот звук, который хотим.
    {
        switch (situation) //вызываем из свича по имени нужный звук. Названия совпадают с названиями в ассетах
        {
            case NameOfSound.BrokenGlass://звук разбитого стекла
                CaseServiceSituation(0);// тут уже используем индекс, без этих ваших рандомов. Знаем, чего хотим. 
                break;
            case NameOfSound.FoleyDoorLock://открываем дверь
                CaseServiceSituation(1);// индекс соотвествует очередности в инспекторе
                break;
            case NameOfSound.WalkOneStep://звук одного шага
                CaseServiceSituation(2);
                break;
            case NameOfSound.CheckGarbage://шумим проверяя мусорку
                CaseServiceSituation(3);
                break;
            case NameOfSound.DogBarking://собака лает за дверью соседа
                CaseServiceSituation(4);
                break;
            case NameOfSound.DoorBell://обыкновенный звонок в дверь
                CaseServiceSituation(5);
                break;
            case NameOfSound.ReadingBook://звук чтения книги или записки
                CaseServiceSituation(6);
                break;
            case NameOfSound.ThunderWeather://раскаты грома, звуки грозовой погоды без шума дождя
                CaseServiceSituation(7);
                break;
            default:
                break;
        }
        void CaseServiceSituation(int SituationNumberOfSound)// сервисный метод для удобоваримости вида свича
        {
            SoundAudioSource.PlayOneShot(audioClipsSound[SituationNumberOfSound]);// проигрываем из аудиосорса элемент с индексом
        }
    }
}
