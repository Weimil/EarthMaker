using System;
using UnityEngine;

// ReSharper disable PossibleLossOfFraction
// ReSharper disable IntVariableOverflowInUncheckedContext

namespace Miscellaneous
{
    public static class Mathw
    {
        public static Vector2 Vector2IntMod(Vector2 vectorA, int mod)
        {
            return Vector2IntMod((int) vectorA.x, (int) vectorA.y, mod);
        }

        public static Vector2 Vector2IntMod(int xA, int yA, int mod)
        {
            return new Vector2(
                xA % mod,
                yA % mod
            );
        }

        public static Vector2 Vector2IntAbs(Vector2 vector)
        {
            return Vector2IntAbs((int) vector.x, (int) vector.y);
        }

        public static Vector2 Vector2IntAbs(int xA, int yA)
        {
            return new Vector2(
                Math.Abs(xA),
                Math.Abs(yA)
            );
        }

        public static Vector2 Vector2IntSign(Vector2 vector)
        {
            return Vector2IntSign((int) vector.x, (int) vector.y);
        }

        public static Vector2 Vector2IntSign(int xA, int yA)
        {
            return new Vector2(
                xA >= 0 ? 1 : -1,
                yA >= 0 ? 1 : -1
            );
        }

        public static Vector2 Vector2IntWrap(Vector2 vectorA)
        {
            return Vector2IntWrap((int) vectorA.x, (int) vectorA.y);
        }

        public static Vector2 Vector2IntWrap(int xA, int yA)
        {
            return new Vector2(
                xA % 2 == 0 ? xA * 0.5f + 1 : (xA * 0.5f + 1) * -1,
                yA % 2 == 0 ? yA * 0.5f + 1 : (yA * 0.5f + 1) * -1
            );
        }

        public static Vector2 Vector2IntWrapOffset(Vector2 vectorA, Vector2 vectorB)
        {
            return Vector2IntWrapOffset((int) vectorA.x, (int) vectorA.y, (int) vectorB.x, (int) vectorB.y);
        }

        public static Vector2 Vector2IntWrapOffset(Vector2 vectorA, int offset)
        {
            return Vector2IntWrapOffset((int) vectorA.x, (int) vectorA.y, offset, offset);
        }

        public static Vector2 Vector2IntWrapOffset(Vector2 vectorA, int xA, int yA)
        {
            return Vector2IntWrapOffset((int) vectorA.x, (int) vectorA.y, xA, yA);
        }

        public static Vector2 Vector2IntWrapOffset(int xA, int yA, Vector2 vectorA)
        {
            return Vector2IntWrapOffset(xA, yA, (int) vectorA.x, (int) vectorA.y);
        }

        public static Vector2 Vector2IntWrapOffset(int xA, int yA, int xB, int yB)
        {
            int nX = (int) (xA * 0.5f * xB + xB * 0.5f);
            nX = xA % 2 == 0 ? nX : nX * -1;

            int nY = (int) (yA * 0.5f * yB + yB * 0.5f);
            nY = yA % 2 == 0 ? nY : nY * -1;

            return new Vector2(nX, nY);
        }

        public static Vector2 Vector2IntDivision(Vector2 vectorA, int div)
        {
            return Vector2IntDivision((int) vectorA.x, (int) vectorA.y, div);
        }

        public static Vector2 Vector2IntDivision(int xA, int yA, int div)
        {
            return new Vector2(
                xA / div,
                yA / div
            );
        }


        public static Vector3 Vector3IntMod(Vector3 vectorA, int mod)
        {
            return Vector3IntMod((int) vectorA.x, (int) vectorA.y, (int) vectorA.z, mod);
        }

        public static Vector3 Vector3IntMod(int xA, int yA, int zA, int mod)
        {
            return new Vector3(
                xA % mod,
                yA % mod,
                zA % mod
            );
        }

        public static Vector3 Vector3IntAbs(Vector3 vectorA)
        {
            return Vector3IntAbs((int) vectorA.x, (int) vectorA.y, (int) vectorA.z);
        }

        public static Vector3 Vector3IntAbs(int xA, int yA, int zA)
        {
            return new Vector3(
                Math.Abs(xA),
                Math.Abs(yA),
                Math.Abs(zA)
            );
        }

        public static Vector3 Vector3IntSign(Vector3 vectorA)
        {
            return Vector3IntSign((int) vectorA.x, (int) vectorA.y, (int) vectorA.z);
        }

        public static Vector3 Vector3IntSign(int xA, int yA, int zA)
        {
            return new Vector3(
                xA >= 0 ? 1 : -1,
                yA >= 0 ? 1 : -1,
                zA >= 0 ? 1 : -1
            );
        }

        public static Vector3 Vector3IntWrap(Vector3 vector)
        {
            return Vector3IntWrap((int) vector.x, (int) vector.y, (int) vector.z);
        }

        public static Vector3 Vector3IntWrap(int xA, int yA, int zA)
        {
            return new Vector3(
                xA * 0.5f + 1 * xA % 2 == 0 ? 1 : -1,
                yA * 0.5f + 1 * yA % 2 == 0 ? 1 : -1,
                zA * 0.5f + 1 * zA % 2 == 0 ? 1 : -1
            );
        }

        public static Vector3 Vector3IntWrapOffset(int xA, int yA, int zA, int offset)
        {
            return Vector3IntWrapOffset(xA, yA, zA, offset, offset, offset);
        }

        public static Vector3 Vector3IntWrapOffset(int xA, int yA, int zA, Vector3 vector)
        {
            return Vector3IntWrapOffset(xA, yA, zA, (int) vector.x, (int) vector.y, (int) vector.z);
        }

        public static Vector3 Vector3IntWrapOffset(int xA, int yA, int zA, int xB, int yB, int zB)
        {
            return new Vector3(
                (int) (xA * 0.5f * xB + xB * 0.5f) * xA % 2 == 0 ? 1 : -1,
                (int) (yA * 0.5f * yB + yB * 0.5f) * yA % 2 == 0 ? 1 : -1,
                (int) (zA * 0.5f * zB + zB * 0.5f) * zA % 2 == 0 ? 1 : -1
            );
        }

        public static Vector3 Vector3IntDivision(Vector3 vectorA, int div)
        {
            return Vector3IntDivision((int) vectorA.x, (int) vectorA.y, (int) vectorA.z, div);
        }

        public static Vector3 Vector3IntDivision(int xA, int yA, int zA, int div)
        {
            return new Vector3(
                xA / div,
                yA / div,
                zA / div
            );
        }
    }
}