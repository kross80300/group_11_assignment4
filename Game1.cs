using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using project2;

namespace group_11_assignment4;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private Texture2D _planetTexture;
    private Texture2D _starTexture;
    private Texture2D _asteroidTexture;
    private Vector2 _planetPosition;
    private List<Star> stars = new List<Star>();
    private Asteroid asteroid;
    private Spaceship spaceship1;
    private Spaceship spaceship2;
    private Texture2D spaceship;
    private Texture2D thrust;

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

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        // TODO: use this.Content to load your game content here
        _planetTexture = Content.Load<Texture2D>("img/planet");
        _starTexture = Content.Load<Texture2D>("img/star");
        _asteroidTexture = Content.Load<Texture2D>("img/asteroid");
        _spaceship = Content.Load<Texture2D>("img/spaceship");
        _thrust = Content.Load<Texture2D>("img/thrust");

        asteroid = new Asteroid(_asteroidTexture, _graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);

        spaceship1 = new Spaceship(_spaceship, _thrust, new Vector2(0, 0), new Vector2(2, 1), 0.4f);
        spaceship2 = new Spaceship(_spaceship, _thrust, new Vector2(200, 0), new Vector2(5, 2), 0.5f);

        InitializeTextures();
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here
        foreach (var star in stars)
        {
            star.Update(gameTime);
        }

        asteroid.Update(gameTime);
        spaceship1.move(1600, 800, 0.4f)
        spaceship2.move(1600, 800, 0.5f)

        base.Update(gameTime);
    }
    
    private void InitializeTextures()
    {
        for (int i = 0; i < numberOfStars; i++)
        {
            float x = (float)(random.NextDouble() * GraphicsDevice.Viewport.Width);
            float y = (float)(random.NextDouble() * GraphicsDevice.Viewport.Height);

            stars.Add(new Star(_starTexture, new Vector2(x, y), random));
        }
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Black);

        _spriteBatch.Begin();
        spaceship1.display(spriteBatch, 0.4f)
        spaceship2.display(spriteBatch, 0.5f)
        _spriteBatch.End();

        _spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.Additive);
        foreach (var star in stars)
        {
            star.Draw(_spriteBatch);
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

        _spriteBatch.Begin();
        asteroid.Draw(_spriteBatch);
        _spriteBatch.End();

        base.Draw(gameTime);
    }

    public class StarTextureInstance
    {
        public Vector2 Position { get; set; }
        public float Alpha { get; set; }
        public float Time { get; set; }
        public float TwinkleSpeed { get; set; }
    }
}
