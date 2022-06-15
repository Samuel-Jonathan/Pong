using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pong
{
    public class Ball
    {
        //Texture
        private Texture2D texture;

        //Position de la balle
        private Vector2 position;

        //Vitesse
        private Vector2 speed;

        //Taille de la texture
        int width;
        int height;

        public Ball(Texture2D texture, Vector2 position, Vector2 speed, int width, int height)
        {
            this.texture = texture;
            this.position = position;
            this.speed = speed;
            this.width = width;
            this.height = height;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }

        public void Move()
        {
            //Mouvement de la balle
            Vector2 newPosition = Vector2.Add(position, speed);
            position.X = newPosition.X;
            position.Y = newPosition.Y;
        }

        public void Collision(int widthWindow, int heightWindow)
        {
            //Murs
            int left = 0;
            int right = widthWindow - width;
            int top = 0;
            int bottom = heightWindow - height;

            //Collision 
            if (position.Y >= bottom)
            {

                speed.Y *= -1;
            }
            else if (position.X >= right)
            {
                speed.X *= -1;
                speed.Y *= 1;
            }
            else if (position.Y <= top)
            {
                speed.Y *= -1;
            }
            else if (position.X <= left)
            {
                speed.X *= -1;

            }

        }
    }
}
