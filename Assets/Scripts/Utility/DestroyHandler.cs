using UnityEngine;

namespace JMRSDKExampleSnippets
{
    /// <summary>
    /// Handles lifetime of gameobject.
    /// </summary>
    public class DestroyHandler : MonoBehaviour
    {
        [SerializeField] private bool autoDestroy; 
        /// <summary>
        /// lifetime of the particle after which gameobject will be destroyed.
        /// </summary>
        public float lifeTime = 40f;

        private void Start()
        {
            if (autoDestroy)
            {
                Destroy(this.gameObject, lifeTime);
            }
        }

        public void DestroyGameObject(float delayToDestroy)
        {
            Destroy(this.gameObject, delayToDestroy);
        }
    }
}