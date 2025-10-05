using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace project2
{
    public class Asteroid
    {
        private Texture2D texture;
        private Vector2 position;
        private float rotation;
        private float speed;
        private float rotationSpeed;

        private int screenWidth;

        public Asteroid (Texture2D texture, int screenWidth, int screenHeight)
        {
            this.texture = texture;
            this.screenWidth = screenWidth;

            position = new Vector2(0, screenHeight / 2f);
            rotation = 0f;
            speed = 200f;
            rotationSpeed = 1.5f;
        }

        public void Update(GameTime gameTime)
        {
            float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;

            position.X += speed*dt;
            rotation += rotationSpeed*dt;

            if (position.X > screenWidth + texture.Width)
            {
                position.X = -texture.Width;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, null, Color.White, rotation,
            new Vector2(texture.Width / 2f, texture.Height / 2f), 0.2f,
            SpriteEffects.None, 0f);
        }
    }
}