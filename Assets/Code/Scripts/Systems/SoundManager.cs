using UnityEngine;

public class SoundManager: MonoBehaviour
{
    [SerializeField] AudioSource MusicAudioSource; //���� �������� ��� �� ������ ����� �������
    [SerializeField] AudioSource SoundAudioSource;
    [SerializeField] AudioClip[] audioClipsSound; //��� ����� ������ 
    [SerializeField] AudioClip[] audioClipsMusic; //����� ����� ������

    //**************************************************������*************************************************
    public void RandomPlayMusic()//���� ��������� ����������� ����
    {
        int RandomClipsMusic;//������� ���� ������ ��� �����
        RandomClipsMusic = Random.Range(0, audioClipsMusic.Length-1); //���������� ��������� ����
        MusicAudioSource.PlayOneShot(audioClipsMusic[RandomClipsMusic]); //��������� � ����� ���� ��� ���
    }
    //**************************************************������*************************************************
    //---------------------------------------------------------------------------------------------------------
    //**************************************************�����**************************************************
    public void SituationSound(string SituationNameOfSound)//������������ ���� ����������� ����� ����� �����. ��� �� �� ��������, ����� � ���� ��� ����, ������� �����.
    {
        switch (SituationNameOfSound) //�������� �� ����� �� ����� ������ ����. �������� ��������� � ���������� � �������
        {
            case "BrokenGlass"://���� ��������� ������
                CaseService(0);// ��� ��� ���������� ������, ��� ���� ����� ��������. �����, ���� �����. 
                break;
            case "FoleyDoorLock"://��������� �����
                CaseService(1);// ������ ������������ ����������� � ����������
                break;
            case "WalkOneStep"://���� ������ ����
                CaseService(2);
                break;
            case "CheckGarbage"://����� �������� �������
                CaseService(3);
                break;
            case "DogBarking"://������ ���� �� ������ ������
                CaseService(4);
                break;
            case "DoorBell"://������������ ������ � �����
                CaseService(5);
                break;
            case "ReadingBook"://���� ������ ����� ��� �������
                CaseService(6);
                break;
            case "ThunderWeather"://������� �����, ����� �������� ������ ��� ���� �����
                CaseService(7);
                break;
            default:
                break;
        }

        void CaseService(int SituationNumberOfSound)// ��������� ����� ��� �������������� ���� �����
        {
            MusicAudioSource.PlayOneShot(audioClipsSound[SituationNumberOfSound]);// ����������� �� ���������� ������� � ��������
        }
    }
    //**************************************************�����**************************************************
}
