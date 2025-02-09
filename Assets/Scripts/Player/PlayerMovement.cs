using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float gravity = 9.81f;
    [SerializeField] private float jumpHeight = 2f;

    private CharacterController controller;
    private bool isGrounded;
    private Vector3 velocity;
    private AudioPlayer audioPlayer;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        audioPlayer = GetComponent<AudioPlayer>();
    }

    void Update()
    {
        isGrounded = controller.isGrounded;

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
            //audioPlayer.PlaySoundEffect(SoundEffects.Land); to be added
        }

        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        controller.Move(moveSpeed * Time.deltaTime * move);

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            velocity.y = Mathf.Sqrt(jumpHeight * 2f * gravity);
            //audioPlayer.PlaySoundEffect(SoundEffects.Jump); to be added
        }
        if (move.magnitude > 0.1f && isGrounded)
            audioPlayer.PlaySoundEffect(SoundEffects.Footsteps);

        velocity.y -= gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}