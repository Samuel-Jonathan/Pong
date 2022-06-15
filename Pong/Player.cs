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
        private int x;
        private int y;

        //Vitesse
        private int speed;

        public Player(Texture2D texture, int x, int y, int speed)
        {
            this.texture = texture;
            this.x = x;
            this.y = y;
            this.speed = speed;

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, new Vector2(x, y), Color.White);
        }

        public void MoveLeft()
        {
            //Déplacement du joueur (gauche)
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                y -= speed;
            }else if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                y += speed;
            }
        }

        public void MoveRight()
        {
            //Déplacement du joueur (droit)
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                y -= speed;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                y += speed;
            }
        }

        public void Collision()
        {

            //Coordonnées du haut et bas de la fenêtre
            int top = 0;
            int bottom = 472;

            //Collision du joueur
            if(y <= top)
            {
                y += speed;
            }else if(y >= bottom)
            {
                y -= speed;
            }
        }
    }
}
