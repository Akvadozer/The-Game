using UnityEngine;
using PlayerSpace;

public class AnimationController : MonoBehaviour
{

    private Player _player;
    private Animator _animator;
        
    // Start is called before the first frame update
    void Start()
    {
        _player = GetComponent<Player>();
        _animator = GetComponent<Animator>();
    }

    
    void Update()
    {
        _animator.SetBool("isMove", _player._isMove);
        _animator.SetBool("isGrounded", _player._isGrounded);
        _animator.SetFloat("velocityY",  _player._rb.velocity.y);
    }
}