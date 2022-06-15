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

        //Dimension de la texture
        private int width;
        private int height;

        //Score des joueurs
        int score;

        public Player(Texture2D texture, Vector2 position, int speed, int width, int height)
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

        public Vector2 GetPosition()
        {
            return position;
        }

        public int GetWidth()
        {
            return width;
        }

        public int GetHeight()
        {
            return height;
        }

        public void SetScore(int score)
        {
            this.score += score;
        }

        public int GetScore()
        {
            return score;
        }
    }
}
