using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace rockpaperscissor
{
    public class MoveDisplay : MonoBehaviour
    {
        [SerializeField] List<Icon> icons;
        [SerializeField] GameObject blastVfx;
        private Dictionary<GameData.MOVE, Icon> iconMap = new();
        bool shuffling;
        int counter = 0;

        private void Awake()
        {
            GenerateDictionary();
        }

        private void GenerateDictionary()
        {
            counter = Random.Range(0, icons.Count - 1);
            for (int i = 0; i < icons.Count; i++)
            {
                iconMap.Add(icons[i].myID, icons[i]);
            }
            Debug.Log(iconMap.Count);
        }

        public void ShuffleIcons()
        {
            shuffling = true;
            StartCoroutine(Shuffle());
        }

        public void StopShuffling(GameData.MOVE move)
        {
            shuffling = false;
            HideIcons();
            iconMap[move].gameObject.SetActive(true);
        }

        public void ShowBlastEffect()
        {
            HideIcons();
            ShowBlast();
            Invoke(nameof(HideBlast), GameData.Constants.HIDE_BLAST_DUR);
        }
             
        IEnumerator Shuffle()
        {
            while (shuffling)
            {
                HideIcons();
                if (counter >= icons.Count)
                    counter = 0;

                icons[counter].gameObject.SetActive(true);
                yield return new WaitForSeconds(GameData.Constants.ICON_SHUFFLE_DUR);
                counter++;
            }
            
        }

        private void HideIcons()
        {
            for (int i = 0; i < icons.Count; i++)
            {
                icons[i].gameObject.SetActive(false);
            }
        }

        private void ShowBlast()
        {
            blastVfx.SetActive(true);
        }


        private void HideBlast()
        {
            blastVfx.SetActive(false);
        }



    }
}