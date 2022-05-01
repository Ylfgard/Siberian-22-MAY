using UnityEngine;

namespace PlayerController
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField]
        private Transform _transform;
        [SerializeField]
        private Rigidbody2D _rb2D;
        
        [Header ("Parametrs")]
        [SerializeField]
        private float _speed;
        private Vector2 _dir;

        public void MoveInDirection(Vector2 direction)
        {
            _dir = direction;
        }

        private void FixedUpdate()
        {
            Vector2 offset = _dir * _speed * Time.deltaTime;
            offset += (Vector2)_transform.position;
            _rb2D.MovePosition(offset);
        }
    }
}