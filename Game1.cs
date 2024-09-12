using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PongMonogame
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D ball2Texture;
        private Vector2 ballPosition;
        private float ballSpeed;
        private Texture2D ballTexture;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            //_spriteBatch.Draw(ballTexture, new Vector2(10, 10), Color.White);
            //_spriteBatch.Draw(ballTexture, ballPosition, Color.White);
            _spriteBatch.Draw(
                ball2Texture,
                ballPosition,
                null,
                Color.White,
                0f,
                new Vector2(ball2Texture.Width / 2, ball2Texture.Height / 2),
                Vector2.One,
                SpriteEffects.None,
                0f
            );
            _spriteBatch.End();

            base.Draw(gameTime);
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _graphics.PreferredBackBufferWidth = 2000;
            _graphics.PreferredBackBufferHeight = 1000;
            _graphics.ApplyChanges();

            ballPosition = new Vector2(_graphics.PreferredBackBufferWidth / 2,
                           _graphics.PreferredBackBufferHeight / 2);
            ballSpeed = 800f;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            //ballTexture = Content.Load<Texture2D>("ball");
            ball2Texture = Content.Load<Texture2D>("ball2");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            float updatedBallSpeed = ballSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            var kstate = Keyboard.GetState();

            if (kstate.IsKeyDown(Keys.W))
            {
                ballPosition.Y -= updatedBallSpeed;
            }

            if (kstate.IsKeyDown(Keys.S))
            {
                ballPosition.Y += updatedBallSpeed;
            }

            if (kstate.IsKeyDown(Keys.A))
            {
                ballPosition.X -= updatedBallSpeed;
            }

            if (kstate.IsKeyDown(Keys.D))
            {
                ballPosition.X += updatedBallSpeed;
            }

            if (ballPosition.X > _graphics.PreferredBackBufferWidth - ball2Texture.Width / 2)
            {
                ballPosition.X = _graphics.PreferredBackBufferWidth - ball2Texture.Width / 2;
            }
            else if (ballPosition.X < ball2Texture.Width / 2)
            {
                ballPosition.X = ball2Texture.Width / 2;
            }

            if (ballPosition.Y > _graphics.PreferredBackBufferHeight - ball2Texture.Height / 2)
            {
                ballPosition.Y = _graphics.PreferredBackBufferHeight - ball2Texture.Height / 2;
            }
            else if (ballPosition.Y < ball2Texture.Height / 2)
            {
                ballPosition.Y = ball2Texture.Height / 2;
            }

            base.Update(gameTime);
        }
    }
}