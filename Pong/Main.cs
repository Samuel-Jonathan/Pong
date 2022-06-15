using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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
        private Texture2D background;
        private Texture2D player;

        //Liste des joueurs
        private List<Player> players = new List<Player>();

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
            background = Content.Load<Texture2D>("background");
            player = Content.Load<Texture2D>("player");

            //Joueurs
            Player playerLeft = new Player(player, 40, height / 2, 5);
            players.Add(playerLeft);

            Player playerRight = new Player(player, 760, height / 2, 5);
            players.Add(playerRight);


        }

        protected override void Update(GameTime gameTime)
        {
            for (int i = 0; i < players.Count; i++)
            {
                players[i].Collision();
            }


            players[0].MoveLeft();
            players[1].MoveRight();


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();

            //Dessine l'arrière-plan
            spriteBatch.Draw(background, Vector2.Zero, Color.White);
            
            //Dessine les joueurs
            for(int i = 0; i < players.Count; i++)
            {
                players[i].Draw(spriteBatch);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
