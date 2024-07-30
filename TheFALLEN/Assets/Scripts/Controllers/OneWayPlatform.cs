using System.Collections;
using UnityEngine;

public class OneWayPlatform : MonoBehaviour
{
    #region VARIABLES
    [SerializeField] private GameObject _currentPlatform;

    [SerializeField] private BoxCollider2D _playerCollider;
    #endregion

   //OneWayPlatform movementOnPlatformEnabled;

    private void Start()
    {
        //movementOnPlatformEnabled = GetComponent<OneWayPlatform>();
    }

    #region UNITY FUNCTIONS
    private void Update()
    {
        //movementOnPlatformEnabled.enabled = false;

        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            if(_currentPlatform != null)
            {
                StartCoroutine(DisableCollision());
            }
        }
    }
    #endregion

    #region ONTRIGGER FUNCTIONS
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("OneWayPlatform"))
        {
            _currentPlatform = collision.gameObject;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("OneWayPlatform"))
        {
            _currentPlatform = null;
        }
    }
    #endregion

    #region COROUTINES
    private IEnumerator DisableCollision()
    {
        BoxCollider2D platformCollider = _currentPlatform.GetComponent<BoxCollider2D>();
        Physics2D.IgnoreCollision(_playerCollider, platformCollider);
        yield return new WaitForSeconds(0.25f);
        Physics2D.IgnoreCollision(_playerCollider, platformCollider, false);
    }
    #endregion
}
