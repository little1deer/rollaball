using System;

namespace RollaBall
{
    using UnityEngine;
    using UnityEngine.UI;
    public class ScoreScreenViewer:MonoBehaviour
    {
        public GameObject scoreText;
        public Slider slider;
        public ScoreController scoreController;
       
        private void FixedUpdate()
        {
            scoreText.GetComponent<Text>().text = scoreController.Score.ToString();
        }
        public void SliderChange(float scoreText)
        {
            slider.value = scoreText;
            
        }
    }
}