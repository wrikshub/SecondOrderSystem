using UnityEngine;

namespace wriks.physics
{
    public static class SecondOrderSystem
    {
        public static Vector3 SecondOrderVector3(Vector3 currentPos, Vector3 targetPos, float bounce, float damp,
            ref Vector3 oldPos)
        {
            var oldLocal = currentPos;
            currentPos = Vector3.Lerp(currentPos, targetPos, (1 - bounce) * damp * Time.fixedDeltaTime);
            currentPos = (1 + bounce) * currentPos - (bounce * oldPos);
            oldPos = oldLocal;

            return currentPos;
        }

        public static float SecondOrderFloat(float currentVal, float targetVal, float bounce, float damp,
            ref float oldVal)
        {
            var oldLocal = currentVal;
            currentVal = Mathf.Lerp(currentVal, targetVal, (1 - bounce) * damp * Time.fixedDeltaTime);
            currentVal = (1 + bounce) * currentVal - bounce * oldVal;
            oldVal = oldLocal;

            return currentVal;
        }
    }
}