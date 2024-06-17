using UnityEngine;
using DG.Tweening;

public class HeartFeedback : MonoBehaviour
{
    public float moveDistance = 1f;
    public float scaleMultiplier = 2f;
    public float rotationAngle = 360f;
    public float tweenTime = 1f;

    // Method to setup and start the heart animation
    public void SetupAndPlay(Vector3 spawnPosition)
    {
        // Set the heart's initial position to the spawnPosition
        transform.position = spawnPosition;

        // Perform tweens using DOTween
        Sequence sequence = DOTween.Sequence();

        transform.rotation = Quaternion.identity;

        // Move tween
        sequence.Append(transform.DOLocalMoveY(moveDistance, tweenTime).SetEase(Ease.OutQuad));

        // Scale tween
        sequence.Join(transform.DOScale(transform.localScale * scaleMultiplier, tweenTime).SetEase(Ease.OutBack));

        // Rotation tween
        sequence.Join(transform.DORotate(new Vector3(0, 0, rotationAngle), tweenTime, RotateMode.FastBeyond360).SetEase(Ease.OutQuad));

        // Destroy the heart after tween animation completes
        sequence.AppendCallback(() => Destroy(gameObject));

        // Start the sequence
        sequence.Play();
    }
}
