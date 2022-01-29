using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{


    public GameObject player;
    public float offset;
    public float offsetSmoothing;
    public float minBoundY, maxBoundY, minBoundX, maxBoundX;
    private Vector3 playerPosition;

    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        playerPosition = new Vector3(
            Mathf.Clamp(player.transform.position.x, minBoundX, maxBoundX),
            Mathf.Clamp(player.transform.position.y, minBoundY, maxBoundY),
            transform.position.z
        );

        transform.position = Vector3.Lerp(transform.position, playerPosition, offsetSmoothing * Time.deltaTime);
    }

    public void test()
    {
        playerPosition = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);

        if (player.transform.localScale.x > 0f)
        {
            playerPosition = new Vector3(playerPosition.x + offset, playerPosition.y, playerPosition.z);
        }
        else
        {
            playerPosition = new Vector3(playerPosition.x - offset, playerPosition.y, playerPosition.z);
        }

        transform.position = Vector3.Lerp(transform.position, playerPosition, offsetSmoothing * Time.deltaTime);
    }
    public void Shake()
    {
        StartCoroutine(IShake(0.16f,0.05f));
        Debug.Log("Eeeeita cuzão kkkk vai cair jão kkkkk");
    }

    IEnumerator IShake(float duration, float shake)
    {
        Vector3 originalPos = playerPosition;
        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            float y = Random.Range(playerPosition.y - shake, playerPosition.y + shake);
            float x = Random.Range(playerPosition.x - shake, playerPosition.x + shake);

            transform.localPosition = new Vector3(x, y, playerPosition.z);
            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = originalPos;
    }


}


