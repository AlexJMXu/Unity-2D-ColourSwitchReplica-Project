using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

	public float jumpForce = 10f;

	public Rigidbody2D rb;
	public SpriteRenderer sr;

	public string currentColour;

	public Color cyan;
	public Color yellow;
	public Color magenta;
	public Color pink;

	private bool startMovement;

	void Start() {
		SetRandomColour();
	}

	void Update() {
		if (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0)) {
			if (!startMovement) {
				rb.gravityScale = 3f;
				startMovement = true;
			}

			rb.velocity = Vector2.up * jumpForce;
		}
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.tag == "ColourChanger") {
			SetRandomColour();
			Destroy(col.gameObject);
			return;
		}

		if (col.tag != currentColour) {
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
	}

	void SetRandomColour() {
		int index = Random.Range(0, 4);

		switch (index) {
			case 0:
				if (currentColour != "Cyan") currentColour = "Cyan";
				else currentColour = "Yellow";
				sr.color = cyan;
				break;
			case 1:
				if (currentColour != "Yellow") currentColour = "Yellow";
				else currentColour = "Magenta";
				sr.color = yellow;
				break;
			case 2:
				if (currentColour != "Magenta") currentColour = "Magenta";
				else currentColour = "Pink";
				sr.color = magenta;
				break;
			case 3:
				if (currentColour != "Pink") currentColour = "Pink";
				else currentColour = "Cyan";
				sr.color = pink;
				break;
		}
	}
}
