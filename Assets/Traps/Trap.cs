using PlayerSpace;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TrapSpace
{

    public class Trap : MonoBehaviour
    {

        public delegate void Hit();

        public static event Hit OnHit;

        protected virtual void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.GetComponent<Player>() != null)
            {
                OnHit?.Invoke();
                //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}