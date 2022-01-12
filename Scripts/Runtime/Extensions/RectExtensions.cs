using UnityEngine;

namespace niscolas.UnityUtils.Core.Extensions
{
    public static class RectExtensions
    {
        public static void AddDelta(
            this RectTransform rectTransform,
            float bottomDelta,
            float leftDelta,
            float rightDelta,
            float topDelta)
        {
            rectTransform.SetRect(
                rectTransform.GetLeft() + leftDelta,
                rectTransform.GetTop() + topDelta,
                rectTransform.GetRight() + rightDelta,
                rectTransform.GetBottom() + bottomDelta);
        }

        public static float GetBottom(this RectTransform rectTransform)
        {
            return rectTransform.offsetMin.y;
        }

        public static float GetLeft(this RectTransform rectTransform)
        {
            return rectTransform.offsetMin.x;
        }

        public static float GetRight(this RectTransform rectTransform)
        {
            return -rectTransform.offsetMax.x;
        }

        public static float GetTop(this RectTransform rectTransform)
        {
            return -rectTransform.offsetMax.y;
        }

        public static void SetRect(this RectTransform trs, float left, float top, float right, float bottom)
        {
            trs.offsetMin = new Vector2(left, bottom);
            trs.offsetMax = new Vector2(-right, -top);
        }

        public static RectTransform SetRectBottom(this RectTransform rt, float y)
        {
            rt.offsetMin = new Vector2(rt.offsetMin.x, y);
            return rt;
        }

        public static RectTransform SetRectLeft(this RectTransform rt, float x)
        {
            rt.offsetMin = new Vector2(x, rt.offsetMin.y);
            return rt;
        }

        public static RectTransform SetRectRight(this RectTransform rt, float x)
        {
            rt.offsetMax = new Vector2(-x, rt.offsetMax.y);
            return rt;
        }

        public static RectTransform SetRectTop(this RectTransform rt, float y)
        {
            rt.offsetMax = new Vector2(rt.offsetMax.x, -y);
            return rt;
        }
    }
}