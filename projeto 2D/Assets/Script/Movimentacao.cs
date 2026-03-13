using UnityEngine;
using UnityEngine.InputSystem;

public class Movimentacao : MonoBehaviour
{
    public float jumpForce = 100f;

    public BoxCollider2D bc2;

    public Rigidbody2D rb2;

    public Novoinput ni;

    private Vector2 moveDirections;

    public float velocidadeMovimento = 5f;

    [SerializeField] private Animator playAnimator;
    [SerializeField] private AudioSource Player;
    [SerializeField] private AudioClip sfxjump;
    [SerializeField] private AudioClip sfxonground;

    void Awake()
    {
        ni = new Novoinput();
        ni.Player.Pularteste.performed += Jump;        
    }

    private void OnEnable()
    {
        ni.Enable();
    }

    private void OnDisable()
    {
        ni.Disable();
    }

    private void Jump(InputAction.CallbackContext ctx)
    {
        rb2.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        Player.PlayOneShot(sfxjump);
       
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Arvore"))
        { 
          Player.PlayOneShot(sfxonground);
        }
    }

    void FixedUpdate()
    {
        moveDirections = ni.Player.Mover.ReadValue<Vector2>();
        transform.Translate(moveDirections * velocidadeMovimento * Time.deltaTime);

        playAnimator.SetFloat("x", moveDirections.x);
        playAnimator.SetFloat("y", moveDirections.y);

        if (moveDirections != Vector2.zero)
        {
            playAnimator.SetInteger("Andando", 1);
        }

        else
        {
            playAnimator.SetInteger("Andando", 0);
        }
      
    }

    
    
}
