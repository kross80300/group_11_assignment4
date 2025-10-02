using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace group_11_assignment4;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private Texture2D _planetTexture;
    private Texture2D _starTexture;
    private Vector2 _planetPosition;
    private List<StarTextureInstance> instances = new List<StarTextureInstance>();
    private int numberOfStars = 1000;
    Random random = new Random();

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        _graphics.PreferredBackBufferWidth = 1600;
        _graphics.PreferredBackBufferHeight = 800;
        _graphics.ApplyChanges();
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        _planetPosition = new Vector2(1200, 50);
        InitializeTextures();

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        // TODO: use this.Content to load your game content here
        _planetTexture = Content.Load<Texture2D>("img/planet");
        _starTexture = Content.Load<Texture2D>("img/star");
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here

        base.Update(gameTime);
    }
    
    private void InitializeTextures()
    {
        for (int i = 0; i < numberOfStars; i++)
        {
            float x = (float)(random.NextDouble() * GraphicsDevice.Viewport.Width);
            float y = (float)(random.NextDouble() * GraphicsDevice.Viewport.Height);

            instances.Add(new StarTextureInstance { Position = new Vector2(x, y) });
        }
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Black);

        // TODO: Add your drawing code here
        
        _spriteBatch.Begin();

        foreach (var instance in instances)
        {
            _spriteBatch.Draw(_starTexture,
                (Vector2)instance.Position,
                null,
                new Color(255, 255, 255, 20),
                0f,
                Vector2.Zero,
                0.001f,
                SpriteEffects.None,
                0f);
        }
        _spriteBatch.End();
        
        _spriteBatch.Begin();
        _spriteBatch.Draw(_planetTexture,
            _planetPosition,
            null,
            Color.White,
            0f,
            Vector2.Zero,
            0.1f,
            SpriteEffects.None,
            0f);
        _spriteBatch.End();

        base.Draw(gameTime);
    }

    public class StarTextureInstance
    {
        public Vector2 Position { get; set; }
        public Texture2D Texture { get; set; }
    }
}