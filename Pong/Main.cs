using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pong
{
    public class Main : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        //Dimension de la fenêtre
        private int width = 800;
        private int height = 600;

        //Déclaration des textures
        private Texture2D backgroundTexture;
        private Texture2D playerTexture;
        private Texture2D ballTexture;

        //Liste des joueurs
        private List<Player> players = new List<Player>();

        //Liste des balles
        private List<Ball> balls = new List<Ball>();

        //Polices d'écriture
        private SpriteFont font;

        public Main()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            //Dimension de la fenêtre
            graphics.PreferredBackBufferWidth = width;
            graphics.PreferredBackBufferHeight = height;


        }

        protected override void Initialize()
        {

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            //Chargement des textures
            backgroundTexture = Content.Load<Texture2D>("background");
            playerTexture = Content.Load<Texture2D>("player");
            ballTexture = Content.Load<Texture2D>("ball");

            //Joueurs
            Player playerLeft = new Player(playerTexture, new Vector2(40, height / 2), 5, 20,128);
            players.Add(playerLeft);

            Player playerRight = new Player(playerTexture, new Vector2(760, height / 2), 5, 20, 128);
            players.Add(playerRight);

            Ball ball = new Ball(ballTexture, new Vector2(width / 2 - 29, height / 2 - 29), new Vector2(5, 5), 29, 29);
            balls.Add(ball);

            font = Content.Load<SpriteFont>("NewFont");
        }

        protected override void Update(GameTime gameTime)
        {

            Player playerLeft = players[0];
            Player playerRight = players[1];

            //Collisions pour les joueurs
            for (int i = 0; i < players.Count; i++)
            {
                players[i].Collision();
            }

            //Mouvements des joueurs
            playerLeft.MoveLeft();
            playerRight.MoveRight();

            

            //Collisions de la balle sur les murs et mouvements de la balle
            for (int i = 0; i < balls.Count; i++)
            {
                balls[i].Move();
                balls[i].Collision(width, height,players);
                
            }

            //Collisions de la balle avec les joueurs
            for (int i = 0; i < balls.Count; i++)
            {
                balls[i].CollisionWithPlayerLeft(playerLeft.GetPosition(),
                             playerLeft.GetWidth(), playerLeft.GetHeight());

                balls[i].CollisionWithPlayerRight(playerRight.GetPosition(),
                    playerRight.GetWidth(), playerRight.GetHeight());


            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();

            //Dessine l'arrière-plan
            spriteBatch.Draw(backgroundTexture, Vector2.Zero, Color.White);

            //Dessine les joueurs
            for (int i = 0; i < players.Count; i++)
            {
                players[i].Draw(spriteBatch);
            }

            //Dessine la balle
            for(int i = 0; i < balls.Count; i++)
            {
                balls[i].Draw(spriteBatch);
            }

            //Scores
            spriteBatch.DrawString(font, Convert.ToString(players[0].GetScore()), new Vector2(770, 20), Color.White);
            spriteBatch.DrawString(font, Convert.ToString(players[1].GetScore()), new Vector2(10, 20), Color.White);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
