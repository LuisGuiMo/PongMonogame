using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongMonogame.Models
    {
    // Clase que representa la bola del juego
    public class Ball
        {
        private GraphicsDeviceManager _graphics;
        private float Speed;
        private Texture2D Texture;
        private Vector2 Velocity;
        private Vector2 Lore;

        // Dirección y velocidad
        public Ball(Texture2D texture, GraphicsDeviceManager graphics)
            {
            Texture = texture;
            _graphics = graphics;
            Speed = 1000f;

            // Posición inicial en el centro
            Position = new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2);

            // Dirección inicial (puedes ajustarla)
            Velocity = new Vector2(1f, 1f);  // Se moverá diagonalmente al principio
            Velocity.Normalize();  // Asegura que la velocidad esté normalizada
            }
        //new
        public Vector2 Position { get; private set; }
        //new
        public void Draw(SpriteBatch spriteBatch)
            {
            spriteBatch.Draw(
                Texture,
                Position,
                null,
                Color.White,
                0f,
                new Vector2(Texture.Width / 2, Texture.Height / 2),
                Vector2.One,
                SpriteEffects.None,
                0f

            );
            }

        public void Update(GameTime gameTime)
            {
            float updatedSpeed = Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            // Actualizar posición
            Position += Velocity * updatedSpeed;

            // Detectar colisión con los bordes
            if (Position.X <= Texture.Width / 2 || Position.X >= _graphics.PreferredBackBufferWidth - Texture.Width / 2)
                {
                Velocity.X *= -1;  // Cambiar dirección horizontal
                }
            // Detectar colisión con los bordes

            if (Position.Y <= Texture.Height / 2 || Position.Y >= _graphics.PreferredBackBufferHeight - Texture.Height / 2)
                {
                Velocity.Y *= -1;  // Cambiar dirección vertical
                }
            }
        }
    }