using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace rockpaperscissor
{
    public class HudController : MonoBehaviour
    {
        [SerializeField] List<Button> moveBtns;

        public void SetButtonInteraction(bool isBtnActive)
        {
            for (int i = 0; i < moveBtns.Count; i++)
            {
                moveBtns[i].interactable = isBtnActive;
            }
        }
    }
}