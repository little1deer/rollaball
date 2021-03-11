using UnityEngine;
namespace RollaBall
{
    public class BadBonus : InteractiveObject, IFlicker
    {
        private Material _material;
        public ScoreController scoreController;
        private void Awake()
        {
            _material = GetComponent<Renderer>().material;
        }

        protected override void Interaction()
        {
        }

        public void Flicker()
        {
            _material.color = new Color(_material.color.r, _material.color.g, _material.color.b,
                Mathf.PingPong(Time.time, 1.0f));
        }
    }
}