using System;

namespace RollaBall
{
    using UnityEngine;
    using UnityEngine.UI;

    public class ScoreScreenViewer : MonoBehaviour
    {
        public Text scoreText;
        public Slider slider;
        public ScoreController scoreController;
        public KeyController KeyController;
        public Image KeyImage1;
        public Image KeyImage2;
        public Image YouLose;
        public Image YouWin;

        private void FixedUpdate()
        {
            scoreText.text = scoreController.Score.ToString();
            KeyViewer();
        }

        public void SliderChange(float scoreText)
        {
            slider.value = scoreText;
        }

        public void KeyViewer()
        {
            switch (KeyController.Keys)
            {
                case 1:
                    KeyImage1.enabled = true;
                    break;
                case 2:
                    KeyImage1.enabled = true;
                    KeyImage2.enabled = true;
                    break;
                default:
                    KeyImage1.enabled = false;
                    KeyImage2.enabled = false;
                    break;
            }
        }
    }
}