using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using PongMonogame.Models;

namespace PongMonogame
{
    public class Game1 : Game
    {
        // Atributos
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Ball ball;
        private Song song;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = 2000;
            _graphics.PreferredBackBufferHeight = 1000;

            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();
            ball.Draw(_spriteBatch);
            _spriteBatch.End();

            base.Draw(gameTime);
        }

        protected override void Initialize()
        {
            _graphics.ApplyChanges();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            Texture2D ballTexture = Content.Load<Texture2D>("ball2");
            ball = new Ball(ballTexture, _graphics);

            song = Content.Load<Song>("GameMusic");
            MediaPlayer.Play(song);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            ball.Update(gameTime);

            base.Update(gameTime);
        }
    }
}