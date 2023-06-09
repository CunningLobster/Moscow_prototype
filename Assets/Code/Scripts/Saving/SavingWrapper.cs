using Saving;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace RPG.SceneManagement
{
    public class SavingWrapper : MonoBehaviour
    {
        //[SerializeField] float fadeInTime = .5f;
        const string defaultSaveFile = "save";

        // private void Awake()
        // {
        //     StartCoroutine(LoadLastScene());
        // }

        // private IEnumerator LoadLastScene()
        // {
        //     yield return GetComponent<SavingSystem>().LoadLastScene(defaultSaveFile);
        //     Fader fader = FindObjectOfType<Fader>();
        //     fader.FadeOutImmediate();
        //     yield return fader.FadeIn(fadeInTime);
        // }

        private void Update()
        {
            if (Keyboard.current[Key.S].wasPressedThisFrame)
            {
                Save();
            }
            if (Keyboard.current[Key.L].wasPressedThisFrame)
            {
                Load();
            }
            if (Keyboard.current[Key.D].wasPressedThisFrame)
            {
                Delete();
            }
        }

        public void Save()
        {
            GetComponent<SavingSystem>().Save(defaultSaveFile);
        }

        public void Load()
        {
            GetComponent<SavingSystem>().Load(defaultSaveFile);
        }

        public void Delete()
        {
            GetComponent<SavingSystem>().Delete(defaultSaveFile);
        }
    }
}