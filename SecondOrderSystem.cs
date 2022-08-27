 //Second Order Physics solver by Erik Engström, August 2022

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
        
        public static float SecondOrderAngle(float currentRot, float targetRot, float bounce, float damp,
            ref float oldRot)
        {
            var oldLocal = currentRot;
            currentRot = Mathf.LerpAngle(currentRot, targetRot, (1 - bounce) * damp * Time.fixedDeltaTime);
            if (Mathf.Abs(currentRot - oldRot) > 300) { oldRot = oldLocal; }
            currentRot = (1 + bounce) * currentRot - bounce * oldRot;
            oldRot = oldLocal;

            return currentRot;
        }
    }
}
