using UnityEngine;

namespace Assets.Scripts
{
    public class Brick : MonoBehaviour, ICollidable
    {
        private int _hitPoints;

        public int InitialHitPoints;

        private readonly GameObjectDebugger _objectDebugger;

        public Brick()
        {
            _objectDebugger = new GameObjectDebugger(this);
        }

        public void CollisionExit(Collision2D collision)
        {
            if (collision.gameObject.tag == "Ball")
                HitPoints--;
        }
        private int HitPoints
        {
            get { return _hitPoints; }
            set
            {
                _hitPoints = value;

                //Магические константы это тоже плохо. Но это уберется после запила анимации.
                if (_hitPoints <= 0)
                    Destroy(gameObject);

                if (_hitPoints == 2)
                    SetSprite("Images/BrickSpriteCracked");

                if (_hitPoints == 1)
                    SetSprite("Images/BrickSpriteRuined");

                _objectDebugger.UpdateDebugInfo();
            }
        }
        private void SetSprite(string pathToSprite)
        {
            GetComponentInChildren<SpriteRenderer>().sprite = Resources.Load<Sprite>(pathToSprite);
        }
        private void Awake()
        {
            HitPoints = InitialHitPoints; 
        }
    }
}
