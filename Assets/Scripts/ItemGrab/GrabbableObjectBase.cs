using Grabbing;
using UnityEngine;

namespace Ingredient
{
    public class GrabbableObjectBase : MonoBehaviour, IGrabbable
    {
        [SerializeField] protected float lerpSpeed = 10f;
        [SerializeField] protected Rigidbody grabbableRigidbody;
        protected Transform grabPointTransform;

        private void Awake()
        {
            grabbableRigidbody = GetComponent<Rigidbody>();
        }

        public void Grab(Transform grabPointTransform)
        {
            grabbableRigidbody.useGravity = false;
            grabbableRigidbody.isKinematic = true;
            this.grabPointTransform = grabPointTransform;
        }
        public void Drop()
        {
            grabPointTransform = null;
            grabbableRigidbody.useGravity = true;
            grabbableRigidbody.isKinematic = false;
        }

        private void FixedUpdate()
        {
            if (grabPointTransform != null)
            {
                Vector3 targetPosition = Vector3.Lerp(transform.position, grabPointTransform.position, Time.deltaTime * lerpSpeed);
                grabbableRigidbody.MovePosition(targetPosition);
            }
        }


    }
}