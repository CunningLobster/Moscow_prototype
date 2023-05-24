using UnityEngine;

namespace Code.Scripts.Systems
{
    public static class Bootstrapper
    {
        //Создаёт префаб "Resources\System.prefab" на любой сцене при запуске.
        //В этом префабе можно создать различные менеджеры, инициализацию и т.д. (пример - LevelManager)
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void Execute() => Object.DontDestroyOnLoad(Object.Instantiate(Resources.Load("Systems")));
    }
}