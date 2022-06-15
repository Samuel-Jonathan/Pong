using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

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

        public void Collision(int widthWindow, int heightWindow, List<Player> players)
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
                players[1].SetScore(1);

            }
            else if (position.Y <= top)
            {
                speed.Y *= -1;
            }
            else if (position.X <= left)
            {
                speed.X *= -1;
                players[0].SetScore(1);

            }

        }

        public void CollisionWithPlayerLeft(Vector2 positionPlayer, int widthPlayer, int heightPlayer)
        {
            //Collision de la balle avec le joueur à gauche
            if (position.X <= positionPlayer.X + widthPlayer &&
                position.Y + height >= positionPlayer.Y &&
                position.Y <= positionPlayer.Y + heightPlayer)
            {
                speed.X *= -1;
            }
        }

        public void CollisionWithPlayerRight(Vector2 positionPlayer, int widthPlayer, int heightPlayer)
        {
            //Collision de la balle avec le joueur à droite
            if (position.X >= positionPlayer.X - width &&
                position.Y + height >= positionPlayer.Y &&
                position.Y <= positionPlayer.Y + heightPlayer)
            {
                speed.X *= -1;
            }
        }

    
    }
}
