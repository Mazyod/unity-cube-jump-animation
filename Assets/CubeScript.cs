using UnityEngine;
using System.Collections;

public class CubeScript : MonoBehaviour {

	#region Animation Callbacks

	private bool goRight = false;

	public void PieceAnimationOnJump() {

		var location = goRight ? 0.0f : 3.0f;
		LeanTween.moveLocalX(gameObject, location, 0.6f);
		LeanTween.moveLocalY(gameObject, 4.0f, 0.3f)
			.setEase(LeanTweenType.easeOutCubic)
			.setOnComplete(() => 
				LeanTween.moveLocalY(gameObject, 0.5f, 0.3f)
				.setEase(LeanTweenType.easeInCubic)
			);

		goRight = !goRight;
	}

	#endregion
}
