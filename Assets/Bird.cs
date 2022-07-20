using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public float jumpForce = 0.2f;
    public float ySpeed;
    bool protectBird = false;
    float protectBirdTime = 3.0f;
    Material birdMaterial;
    public Transform heartStartPoint;
    public Heart heartPrefab;
    public List<Heart> hearts;
    int maxHeart = 3;
    int hp;

    public void Start()
    {
        birdMaterial = GetComponent<MeshRenderer>().material;

        for (int i = 0; i < maxHeart; i++)
        {
            var heart = Instantiate(heartPrefab, heartStartPoint);
            var transform = heart.GetComponent<RectTransform>();
            heart.filled = true;
            transform.position = new Vector3(heart.width / 2 + i * heart.width, heart.width / 2, 0);
            hearts.Add(heart);
        }

        hp = maxHeart;

    }

    // Update is called once per frame
    void Update()
    {
        ControlY();
        ProtectTimer();
    }

    void ProtectTimer()
    {
        if (protectBird)
        {
            birdMaterial.color = Color.yellow;

            if (protectBirdTime < 0.0f)
            {
                protectBirdTime = 3.0f;
                protectBird = false;
            }
            else
            {
                protectBirdTime -= Time.deltaTime;
            }
        }
        else
        {
            birdMaterial.color = Color.red;
        }
    }

    void ControlY()
    {
        var position = transform.position;
        ySpeed += -9.8f * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ySpeed = jumpForce;
        }

        position.y += ySpeed * Time.deltaTime;

        if (position.y < -GameSystem.instance.mapHeight)
        {
            position.y = -GameSystem.instance.mapHeight;
            DetectHurt();
        }
        else if (position.y > GameSystem.instance.mapHeight)
        {
            position.y = GameSystem.instance.mapHeight;
            DetectHurt();
        }
        transform.position = position;
    }

    public void OnTriggerEnter(Collider collider)
    {
        DetectHurt();
    }

    void DetectHurt()
    {
        if (hp > 0)
            if (!protectBird)
            {
                protectBird = true;
                hp--;
                hearts[hp].filled = false;
            }

        if (hp == 0)
        {
            Debug.Log("Game Over!");
        }
    }
}
