using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalParticles : MonoBehaviour
{
    [SerializeField] private ParticleSystem _emojiAngry;
    [SerializeField] private ParticleSystem _emojiAngry2;
    [SerializeField] private ParticleSystem _emojiHeart;
    [SerializeField] private ParticleSystem _heartPoof;
    [SerializeField] private ParticleSystem _featherExplosion;
    [SerializeField] private ParticleSystem _bubbles;

    public ParticleSystem EmojiAngry => _emojiAngry;
    public ParticleSystem EmojiAngry2 => _emojiAngry2;
    public ParticleSystem EmojiHeart => _emojiHeart;
    public ParticleSystem HeartPoof => _heartPoof;
    public ParticleSystem FeatherExplosion => _featherExplosion;

    public ParticleSystem Bubbles => _bubbles;
}
