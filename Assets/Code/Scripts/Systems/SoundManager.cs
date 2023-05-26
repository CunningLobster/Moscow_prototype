using UnityEngine;

public class SoundManager: MonoBehaviour
{
    [SerializeField] AudioSource MusicAudioSource; //пока выжимаем все из одного аудио ресурса
    [SerializeField] AudioSource SoundAudioSource;
    [SerializeField] AudioClip[] audioClipsSound; //наш набор звуков 
    [SerializeField] AudioClip[] audioClipsMusic; //здесь набор музыки

    //**************************************************МУЗЫКА*************************************************
    public void RandomPlayMusic()//пока случайная музыкальная тема
    {
        int RandomClipsMusic;//запишим сюда рандом для крика
        RandomClipsMusic = Random.Range(0, audioClipsMusic.Length-1); //определили случайную тему
        MusicAudioSource.PlayOneShot(audioClipsMusic[RandomClipsMusic]); //проиграли её через плей ван шот
    }
    //**************************************************МУЗЫКА*************************************************
    //---------------------------------------------------------------------------------------------------------
    //**************************************************ЗВУКИ**************************************************
    public void SituationSound(string SituationNameOfSound)//Ситуационный звук проигрываем через этого метод. Что бы не путаться, пишем в него тот звук, который хотим.
    {
        switch (SituationNameOfSound) //вызываем из свича по имени нужный звук. Названия совпадают с названиями в ассетах
        {
            case "BrokenGlass"://звук разбитого стекла
                CaseService(0);// тут уже используем индекс, без этих ваших рандомов. Знаем, чего хотим. 
                break;
            case "FoleyDoorLock"://открываем дверь
                CaseService(1);// индекс соотвествует очередности в инспекторе
                break;
            case "WalkOneStep"://звук одного шага
                CaseService(2);
                break;
            case "CheckGarbage"://шумим проверяя мусорку
                CaseService(3);
                break;
            case "DogBarking"://собака лает за дверью соседа
                CaseService(4);
                break;
            case "DoorBell"://обыкновенный звонок в дверь
                CaseService(5);
                break;
            case "ReadingBook"://звук чтения книги или записки
                CaseService(6);
                break;
            case "ThunderWeather"://раскаты грома, звуки грозовой погоды без шума дождя
                CaseService(7);
                break;
            default:
                break;
        }

        void CaseService(int SituationNumberOfSound)// сервисный метод для удобоваримости вида свича
        {
            MusicAudioSource.PlayOneShot(audioClipsSound[SituationNumberOfSound]);// проигрываем из аудиосорса элемент с индексом
        }
    }
    //**************************************************ЗВУКИ**************************************************
}
