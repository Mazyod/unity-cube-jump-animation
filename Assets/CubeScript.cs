using UnityEngine;
using System.Collections;

public class CubeScript : MonoBehaviour {

	public enum Animation {
		Jump,
		Swpn,
		Death,
		Promotion,
	}

	public Animation animationType;

	private Vector3 initialPosition;
	private Animator animator;
	private bool goRight = false;


	#region init & dealloc

	void Start() {

		animator = GetComponent<Animator>();
		initialPosition = transform.localPosition;

		switch (animationType) {
		case Animation.Jump:
			PerformJumpAnimation();
			break;

		case Animation.Swpn:
			PerformSpwnAnimation();
			break;

		case Animation.Death:
			PerformDeathAnimation();
			break;

		case Animation.Promotion:
			PerformPromotionAnimation();
			break;
		}
	}

	#endregion

	#region private methods

	private void PerformJumpAnimation() {
		animator.SetTrigger("jump");
	}

	private void PerformSpwnAnimation() {

	}

	private void PerformDeathAnimation() {
		animator.SetTrigger("die");
	}

	private void PerformPromotionAnimation() {
		animator.SetTrigger("promote");
	}

	#endregion

	#region Animation Callbacks

	public void PieceAnimationOnJump() {

		var location = initialPosition.x + (goRight ? 0.0f : 3.0f);

		LeanTween.moveLocalX(gameObject, location, 0.6f);
		LeanTween.moveLocalY(gameObject, 4.0f, 0.3f)
			.setEase(LeanTweenType.easeOutCubic)
			.setOnComplete(() => 
				LeanTween.moveLocalY(gameObject, 0.5f, 0.3f)
				.setEase(LeanTweenType.easeInCubic)
			);

		goRight = !goRight;
	}

	public void PieceAnimationOnDeathStart() {

		var location = initialPosition.y + 2f;
		LeanTween.moveLocalY(gameObject, location, 0.38f)
			.setEase(LeanTweenType.easeInOutExpo);
	}

	public void PieceAnimationOnDeathEnd() {
	}

	public void PieceAnimationOnSpwnDidScale() {
		LeanTween.moveLocalY(gameObject, initialPosition.y, 0.25f)
			.setEase(LeanTweenType.easeInCubic);
	}

	public void PieceAnimationOnSpwnEnd() {

	}

	#endregion
}
