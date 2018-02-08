using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BallController : MonoBehaviour {

	//ボールが見える可能性のあるz軸の最大値
	private float visiblePosZ = -6.5f;

	//ゲームオーバを表示するテキスト
	private GameObject gameoverText;

	//score text
	private GameObject scoreText;

	//store score
	private int score = 0;

	// Use this for initialization
	void Start () {
		//シーン中のGameOverTextオブジェクトを取得
		this.gameoverText = GameObject.Find("GameOverText");

		//get ScoreText GameObject
		this.scoreText = GameObject.Find("ScoreText");
	}

	// Update is called once per frame
	void Update () {
		//ボールが画面外に出た場合
		if (this.transform.position.z < this.visiblePosZ) {
			//GameoverTextにゲームオーバを表示
			this.gameoverText.GetComponent<Text> ().text = "Game Over";
		}
	}

	//衝突時に呼ばれる関数
	void OnCollisionEnter(Collision other) {
		string collisionTag = other.gameObject.tag;

		//calculate score
		if (collisionTag == "SmallStarTag") {
			score += 2;

		} else if (collisionTag == "LargeStarTag") {
			score += 10;

		} else if (collisionTag == "SmallCloudTag") {
			score += 20;

		} else if (collisionTag == "LargeCloudTag") {
			score += 100;
		}

		//display present score
		this.scoreText.GetComponent<Text> ().text = score.ToString ();
	}
}