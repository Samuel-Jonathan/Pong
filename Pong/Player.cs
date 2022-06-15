using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace Pong
{
    public class Player
    {

        //Texture
        private Texture2D texture;

        //Position du joueur
        private Vector2 position;

        //Vitesse
        private int speed;

        public Player(Texture2D texture, Vector2 position, int speed)
        {
            this.texture = texture;
            this.position = position;
            this.speed = speed;

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, new Vector2(position.X, position.Y), Color.White);
        }

        public void MoveLeft()
        {
            //Déplacement du joueur (gauche)
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                position.Y -= speed;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                position.Y += speed;
            }
        }

        public void MoveRight()
        {
            //Déplacement du joueur (droit)
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                position.Y -= speed;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                position.Y += speed;
            }
        }

        public void Collision()
        {

            //Murs
            int top = 0;
            int bottom = 472;

            //Collision du joueur
            if (position.Y <= top)
            {
                position.Y += speed;
            }
            else if (position.Y >= bottom)
            {
                position.Y -= speed;
            }
        }
    }
}
