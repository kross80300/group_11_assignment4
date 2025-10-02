using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace group_11_assignment4;

public class Star
    {
        
        private Vector2 position;
        private float alpha;
        private float time;
        private float twinkleSpeed;
        private Texture2D _starTexture;

        public Star(Texture2D _starTexture, Vector2 position, Random rng)
        {
            this._starTexture = _starTexture;
            this.position = position;

            alpha = 1f;
            time = (float)(rng.NextDouble() * MathF.PI * 2);
            twinkleSpeed = 0.5f + (float)rng.NextDouble() * 2f;
        }

        public void Update(GameTime gameTime)
        {
            float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;
            time += dt * twinkleSpeed;

            // Smooth twinkle between 0.2 and 1
            alpha = 0.2f + ((MathF.Sin(time) + 1f) / 2f) * 0.8f;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                _starTexture,
                position,
                null,
                Color.White * alpha,
                0f,
                new Vector2(_starTexture.Width / 2f, _starTexture.Height / 2f),
                0.003f,
                SpriteEffects.None,
                0f
            );
        }
    }