using System;
using System.Collections;
using RollaBall;
using UnityEngine;

    public class ScoreController: MonoBehaviour
    {
        [NonSerialized]public float Score = 1000;
        public Player Player;
        private float _speedPlayer;
        private float _decrement;
        public float DecrementCoefficient = 30;
        public ScoreScreenViewer screenBar;
        private void FixedUpdate()
        {
           if (Score<=0)
           {
               screenBar.YouLose.enabled = true;
           }
        }
        
        private void Start()
        {
            screenBar.YouLose.enabled = false;
            screenBar.YouWin.enabled = false;
            StartCoroutine(ScoreCounterCoroutine());
        }

        IEnumerator ScoreCounterCoroutine()
        {
            while (true)
            {
                _speedPlayer = Player.GetSpeedPlayer();
                float speedPlayerMax = 10;
                float speedPlayerMin = 0;
                _decrement = Mathf.InverseLerp(speedPlayerMax, speedPlayerMin, _speedPlayer);
                _decrement = Mathf.RoundToInt(_decrement* DecrementCoefficient);
                Score = Score - _decrement;
                screenBar.SliderChange(Score);
                yield return new WaitForSeconds(1f);
            }
        }
    }
