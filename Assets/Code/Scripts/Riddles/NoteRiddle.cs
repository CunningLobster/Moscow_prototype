using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

namespace Code.Scripts.Riddles
{
    public class NoteRiddle : MonoBehaviour
    {
        [SerializeField] private List<TextMeshProUGUI> letters = new();
        [SerializeField] private NavMeshAgent playerAgent;
        [SerializeField] private InteractableObject exitToPark;
        public void SelectLetter(string letter)
        {
            foreach (var t in letters)
            {
                if (t.text.Length == 0)
                {
                    t.text = letter;
                    break;
                }
            }

            if (letters.TrueForAll(x => x.text.Length == 1))
            {
                CheckAnswer();
            }
        }

        private void CheckAnswer()
        {
            string word = "";

            foreach (var t in letters)
            {
                word+=t.text;
            }

            if (word == "ПАРК")
            {
                gameObject.SetActive(false);
                playerAgent.enabled = true;
                exitToPark._isAvailable = true;
            }
            else
            {
                foreach (var t in letters)
                {
                    t.text = "";
                }
            }
        }
    }
}
