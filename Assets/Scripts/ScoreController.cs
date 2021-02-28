using System;
using RollaBall;
using UnityEngine;

    public class ScoreController: MonoBehaviour
    {
        [NonSerialized]public float Score = 1000;
        public Player player;
        private float _speedPlayer;
        private float _decrement;
        public float decrementCoefficient = 30;
        public ScoreScreenViewer screenBar;
        private void FixedUpdate()
        {
           // if (Score==0)
            //{
                //GameOver
            //}
        }
        
        private void Start()
        {
            InvokeRepeating("ScoreCounter",1,1);
        }

        private void ScoreCounter()
        {
            _speedPlayer = player.GetSpeedPlayer();
            float speedPlayerMax = 10;
            float speedPlayerMin = 0;
            _decrement = Mathf.InverseLerp(speedPlayerMax, speedPlayerMin, _speedPlayer);
            _decrement = Mathf.RoundToInt(_decrement* decrementCoefficient);
            Score= Score - _decrement;
            screenBar.SliderChange(Score);
        }
    }
