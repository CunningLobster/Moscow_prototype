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
    public void SituationSound(NameOfSound situation)//������������ ���� ����������� ����� ����� �����. ��� �� �� ��������, ����� � ���� ��� ����, ������� �����.
    {
        switch (situation) //�������� �� ����� �� ����� ������ ����. �������� ��������� � ���������� � �������
        {
            case NameOfSound.BrokenGlass://���� ��������� ������
                CaseService(0);// ��� ��� ���������� ������, ��� ���� ����� ��������. �����, ���� �����. 
                break;
            case NameOfSound.FoleyDoorLock://��������� �����
                CaseService(1);// ������ ������������ ����������� � ����������
                break;
            case NameOfSound.WalkOneStep://���� ������ ����
                CaseService(2);
                break;
            case NameOfSound.CheckGarbage://����� �������� �������
                CaseService(3);
                break;
            case NameOfSound.DogBarking://������ ���� �� ������ ������
                CaseService(4);
                break;
            case NameOfSound.DoorBell://������������ ������ � �����
                CaseService(5);
                break;
            case NameOfSound.ReadingBook://���� ������ ����� ��� �������
                CaseService(6);
                break;
            case NameOfSound.ThunderWeather://������� �����, ����� �������� ������ ��� ���� �����
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
}
