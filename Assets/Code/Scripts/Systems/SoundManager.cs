using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Linq;
using System;

public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioSource MusicAudioSource; //���� �������� ��� �� ������ ����� �������
    [SerializeField] AudioSource SoundAudioSource;
    [SerializeField] AudioClip[] audioClipsSound; //��� ����� ������
    [SerializeField] AudioClip[] audioClipsMusic; //����� ����� ������

    public static SoundManager Instance;
        
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }
    //**************************************************������*************************************************
    public void PlaySceneMusic()//���� ��������� ����������� ����
    {
        int CurrentSceneIndex = SceneManager.GetActiveScene().buildIndex; //�������� ���������� ����� � ����������
        MusicAudioSource.PlayOneShot(audioClipsMusic[CurrentSceneIndex]); //����������� ������ � ���������� ������� �����
    }
    //**************************************************������*************************************************
    //---------------------------------------------------------------------------------------------------------
    //**************************************************�����**************************************************

    public void PlaySituationSound(AudioClip situation)//����� ������������� ��������� ������������ ���� ����� ����� �������� ��� ������
    {
        SoundAudioSource.PlayOneShot(situation);
    }

    public AudioClip LoadClip(NameOfSound name) //����� �������� ������������� �����
    {
        var clipDict = MapSounds();
        AudioClip clip = clipDict[name]; //��������
        return clip;
    }

    Dictionary<NameOfSound, AudioClip> MapSounds()
    {
        Dictionary<NameOfSound, AudioClip> clipDict = new Dictionary<NameOfSound, AudioClip>();
        var names = Enum.GetValues(typeof(NameOfSound));
        for (int i = 0; i < names.Length; i++)
        {
            clipDict[(NameOfSound)names.GetValue(i)] = audioClipsSound[i];
        }
        return clipDict;
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
        PlasticBag,
        KnockDoor
    }
    //**************************************************�����*************************************************
    //---------------------------------------------------------------------------------------------------------
    //**********************************************������ �����**********************************************
    public void OldSituationSound(NameOfSound situation)//������������ ���� ����������� ����� ����� �����. ��� �� �� ��������, ����� � ���� ��� ����, ������� �����.
    {
        switch (situation) //�������� �� ����� �� ����� ������ ����. �������� ��������� � ���������� � �������
        {
            case NameOfSound.BrokenGlass://���� ��������� ������
                CaseServiceSituation(0);// ��� ��� ���������� ������, ��� ���� ����� ��������. �����, ���� �����. 
                break;
            case NameOfSound.FoleyDoorLock://��������� �����
                CaseServiceSituation(1);// ������ ������������ ����������� � ����������
                break;
            case NameOfSound.WalkOneStep://���� ������ ����
                CaseServiceSituation(2);
                break;
            case NameOfSound.CheckGarbage://����� �������� �������
                CaseServiceSituation(3);
                break;
            case NameOfSound.DogBarking://������ ���� �� ������ ������
                CaseServiceSituation(4);
                break;
            case NameOfSound.DoorBell://������������ ������ � �����
                CaseServiceSituation(5);
                break;
            case NameOfSound.ReadingBook://���� ������ ����� ��� �������
                CaseServiceSituation(6);
                break;
            case NameOfSound.ThunderWeather://������� �����, ����� �������� ������ ��� ���� �����
                CaseServiceSituation(7);
                break;
            case NameOfSound.PlasticBag://������� �����, ����� �������� ������ ��� ���� �����
                CaseServiceSituation(8);
                break;
            case NameOfSound.KnockDoor://������� �����, ����� �������� ������ ��� ���� �����
                CaseServiceSituation(9);
                break;
            default:
                break;
        }
        void CaseServiceSituation(int SituationNumberOfSound)// ��������� ����� ��� �������������� ���� �����
        {
            SoundAudioSource.PlayOneShot(audioClipsSound[SituationNumberOfSound]);// ����������� �� ���������� ������� � ��������
        }
    }
}
