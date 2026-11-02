using UnityEngine;
using DG.Tweening;
public static class TweenHelper
{
    public static Sequence PunchUp(Transform _transform) 
    {
        Sequence sq = DOTween.Sequence();

        sq.Append(_transform.DOLocalMoveY(1.0f, 1.0f));
        
        sq.Join(_transform.DOPunchScale(new Vector3(1.5f, 1.5f, 1.5f), 0.7f));
        return sq;
    }

    public static Sequence RockDown(Transform _transform, float moveAmount = 1.0f)
    {
        Sequence sq = DOTween.Sequence();

        sq.Append(_transform.DOLocalMoveY(0.5f, 1.0f)); // Move the object up slightly
        sq.Append(_transform.DOLocalMoveY(0.0f, 1.0f)); // Move the object back down
        sq.Append(_transform.DOLocalMoveY(moveAmount, 1.0f));
        return sq;
    }
}
