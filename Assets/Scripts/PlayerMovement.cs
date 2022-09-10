using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float playerSpeed = 8f;

    void Start()
    {
        playerSpeed = GameManager.instance.doofusDiary.diaryData.player_data.speed;
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            this.transform.Translate(Vector3.forward * Time.deltaTime * playerSpeed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            this.transform.Translate(Vector3.back * Time.deltaTime * playerSpeed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.Translate(Vector3.left * Time.deltaTime * playerSpeed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.Translate(Vector3.right * Time.deltaTime * playerSpeed);
        }

        if (transform.position.y < -10f)
        {
            GameManager.instance.GameOver();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PulpitCollider")
        {
            GameManager.instance.IncreaseScore();
            Destroy(other);
        }
    }
}