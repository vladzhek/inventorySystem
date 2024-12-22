using DG.Tweening;
using UnityEngine;

namespace Services
{
    public class DOTWeenService
    {
        public void Snaping(Transform startPos, Transform endPos, float duration)
        {
            startPos.DOMove(endPos.position, duration).SetEase(Ease.InOutQuad);
        }
    }
}