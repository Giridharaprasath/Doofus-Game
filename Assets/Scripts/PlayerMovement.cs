using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float playerSpeed = 8f;

    [Header("Audio Source")]
    [SerializeField]
    private AudioSource playerFalling;

    private bool isPlaying = false;
    private Vector2 move;
    private bool toPause;

    private void Awake()
    {
        InputManager.Controls.Player.Move.performed += ctx => SetMovement(ctx.ReadValue<Vector2>());
        InputManager.Controls.Player.Pause.performed += ctx => toPause = true;

        InputManager.Controls.Player.Move.canceled += ctx => ResetMovement();
        InputManager.Controls.Player.Pause.canceled += ctx => toPause = false;
    }

    private void SetMovement(Vector2 movement) => move = movement;

    private void ResetMovement() => move = Vector2.zero;

    void Start()
    {
        playerSpeed = GameManager.instance.doofusDiary.diaryData.player_data.speed;
    }

    void Update()
    {
        // Player Movement Using Old Unity Input System

        //if(Input.GetKey(KeyCode.W))
        //{
        //    this.transform.Translate(Vector3.forward * Time.deltaTime * playerSpeed);
        //}
        //if (Input.GetKey(KeyCode.S))
        //{
        //    this.transform.Translate(Vector3.back * Time.deltaTime * playerSpeed);
        //}
        //if (Input.GetKey(KeyCode.A))
        //{
        //    this.transform.Translate(Vector3.left * Time.deltaTime * playerSpeed);
        //}
        //if (Input.GetKey(KeyCode.D))
        //{
        //    this.transform.Translate(Vector3.right * Time.deltaTime * playerSpeed);
        //}

        // Player Movement Using New Unity Input System

        transform.Translate(new Vector3(move.x, 0f, move.y) * Time.deltaTime * playerSpeed);

        // When Doofus Falls Down to Trigger Game Over

        if (transform.position.y < -10f)
        {
            GameManager.instance.GameOver();
        }

        // To Player Game Over Sound Effect

        if (transform.position.y < -2f && !isPlaying)
        {
            playerFalling.Play();
            isPlaying = true;
        }

        // To Pause the Game

        if (toPause && GameManager.instance.canPause)
            GameManager.instance.PauseGame();
    }

    // To Find if Doofus Reached a Pulpit

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PulpitCollider")
        {
            GameManager.instance.IncreaseScore();
            Destroy(other);
        }
    }
}