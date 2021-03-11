using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace RollaBall
{
    public class GoodBonus:InteractiveObject, IFly, IRotation
    {
        private float _lengthFly;
        private float _speedRotation=50.0f;
        public ScoreController scoreController;

        private void Awake()
        {
            _lengthFly = Random.Range(1.0f, 5.0f);
        }

        protected override void Interaction()
        {
        }

        public void Rotation()
        {
            transform.Rotate(Vector3.up * (Time.deltaTime * _speedRotation), Space.World);
        }

        public void Fly()
        {
            transform.localPosition = new Vector3(transform.localPosition.x, Mathf.PingPong(Time.time, _lengthFly),
                transform.localPosition.z);
        }
    }
}