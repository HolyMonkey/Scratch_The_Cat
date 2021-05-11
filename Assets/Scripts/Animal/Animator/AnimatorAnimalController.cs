using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorAnimalController : MonoBehaviour
{
    public static class Params
    {
        public const string IsRun = nameof(IsRun);
        public const string IsWalked = nameof(IsWalked);
        public const string IsAngry = nameof(IsAngry);
        public const string IsHappy = nameof(IsHappy);
        public const string Clicked = nameof(Clicked);
        public const string Spin = nameof(Spin);
        public const string Happy = nameof(Happy);

        public const string IsSpin = nameof(IsSpin);
    }

    public static class States
    {
        public const string Idle = nameof(Idle);
        public const string Walk = nameof(Walk);
        public const string Clicked = nameof(Clicked);
        public const string Spin = nameof(Spin);
        public const string Click = nameof(Click);
        public const string Fear = nameof(Fear);
        public const string Angry = nameof(Angry);
        public const string Bounce = nameof(Bounce);
        public const string Munch = nameof(Munch);

        public const string ResizingSpin = nameof(ResizingSpin);
        public const string ResizingBounce = nameof(ResizingBounce);
    }
}
