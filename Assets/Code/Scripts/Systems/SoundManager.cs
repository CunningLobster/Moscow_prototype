using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager: MonoBehaviour
{
    [SerializeField] AudioSource MusicAudioSource; //���� �������� ��� �� ������ ����� �������
    [SerializeField] AudioSource SoundAudioSource;
    [SerializeField] AudioClip[] audioClipsSound; //��� ����� ������
    [SerializeField] AudioClip[] audioClipsMusic; //����� ����� ������

    //**************************************************������*************************************************
    public void PlaySceneMusic()//���� ��������� ����������� ����
    {
        int CurrentSceneIndex = SceneManager.GetActiveScene().buildIndex; //�������� ���������� ����� � ����������
        MusicAudioSource.PlayOneShot(audioClipsMusic[CurrentSceneIndex]); //����������� ������ � ���������� ������� �����
    }
    //**************************************************������*************************************************
    //---------------------------------------------------------------------------------------------------------
    //**************************************************�����**************************************************

    AudioClip LoadClip(NameOfSound name) //����� �������� ������������� �����
    {
        string path = "Audio/Sounds/" + name; //���� ���� ���
        AudioClip clip = Resources.Load<AudioClip>(path); //��������
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
    //**************************************************�����**************************************************
}
