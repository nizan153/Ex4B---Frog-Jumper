using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Frog : MonoBehaviour {


    void Update () {

		if (Input.GetKeyDown(KeyCode.RightArrow))
		{
			transform.rotation = Quaternion.Euler(0f, 0f, -90f);
			Move(Vector3.right);
		}
		else if (Input.GetKeyDown(KeyCode.LeftArrow))
		{
			transform.rotation = Quaternion.Euler(0f, 0f, 90f);
			Move(Vector3.left);
		}
		else if (Input.GetKeyDown(KeyCode.UpArrow))
		{
			transform.rotation = Quaternion.Euler(0f, 0f, 0f);
			Move(Vector3.up);
		}
		else if (Input.GetKeyDown(KeyCode.DownArrow))
		{
			transform.rotation = Quaternion.Euler(0f, 0f, 180f);
			Move(Vector3.down);
		}

	}

	private void Move(Vector3 direction)
    {
		Vector3 destination = transform.position + direction;
		StopAllCoroutines();
		StartCoroutine(Leap(destination));
    }

	private IEnumerator Leap(Vector3 destination)
    {
		Vector3 startPosition = transform.position;
		float elapsed = 0f;
		float duration = 0.2f;

		while(elapsed < duration)
        {
			float t = elapsed / duration;
			transform.position = Vector3.Lerp(startPosition, destination, t);
			elapsed += Time.deltaTime;
			yield return null;
        }
    }

	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.tag == "Car")
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
	}
}
