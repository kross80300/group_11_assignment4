using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace sra2745_assignment4;

public class Spaceship   
{
    public Vector2 Origin { get; set; } = Vector2.Zero;
    public Vector2 Speed { get; set; } = new Vector2(1, 0);
    public Texture2D Texture { get; set; }
    public Texture2D ThrustTexture { get; set; }

    public float Scale { get; set; } = 0.7f;
    public Spaceship(Texture2D texture)
    {
        Texture = texture;
    }

    public Spaceship(Texture2D texture, Texture2D thrustTexture, Vector2 position, Vector2 speed, float scale)
    {
        Texture = texture;
        ThrustTexture = thrustTexture;
        Origin = position;
        Speed = speed;
        Scale = scale;
    }

    // Move and wrap when reaching the edge
    public void Move(int frameWidth, int frameHeight, float scale)
    {
        var newOrigin = Origin + Speed;
        if (newOrigin.X > frameWidth)
        {
            newOrigin.X = 0 - Texture.Width * scale;
        }
        if (newOrigin.Y > frameHeight)
        {
            newOrigin.Y = 0 - Texture.Height * scale;
        }
        Origin = newOrigin;
    }

    public void display(SpriteBatch spriteBatch, float scale)
    {
        spriteBatch.Draw(Texture, Origin, null, Color.White, 0f, Vector2.Zero, Scale, SpriteEffects.None, 0f);
        if (Speed.X > 0 || Speed.Y > 0)
        {
            spriteBatch.Draw(ThrustTexture, Origin + new Vector2(0.0f, 0.0f), null, thrustEffect(scale, Speed), 0f, Vector2.Zero, Scale, SpriteEffects.None, 0f);
        }
    }

    public Color thrustEffect(float scale, Vector2 speed)
    {
        int baseColor = Math.Clamp((int)(speed.X * 30 + speed.Y * 30), 0, 255);
        byte r = (byte)baseColor;
        byte g = (byte)(baseColor * 0.9f);
        byte b = (byte)(baseColor * 0.8f);
        return new Color(r, g, b);
    }





}
