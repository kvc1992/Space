
namespace Space
{

    public partial class Form1 : Form
    {
        PictureBox[] skyBox;//skybox til stjerner
        int backSpeed = 2;//hastighed til stjerner
        Random rnd;//RND altid god at have
        bool moveLeft = false;//Bev�g bold venstre bool
        bool moveRight = false;//Bev�g bold h�jere bool
        int speed = 14;//stjerners hastighed
        int ballSpeedX = 10;//bolds hastighed
        int ballSpeedY = 10;//Bolds hastighed
        List<PictureBox> enemy; //En liste af fjender
        int width = 30;
        int height = 10; //Variabler til vores enemy , vi kan udvide og lege med dem hvis jeg n�r s� langt
        int enemySpeed = 15;
        int score=0;
        private bool enemySpawned=false;
        private bool scoreDivide5() { return score%5==0;}//Hvis vi kan devidiere med fem bliver denne sand
        private bool form2opened=false;

        public Form1()
        {
            InitializeComponent();
            enemy = new List<PictureBox>();
           
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            rnd = new Random();
            //Vi har vores skbox her, fordi vi ikke �nsker �ndre den, den vil v�re random fra gang til gang og vie et nyt fell, men ellers det samme spillet ud   
            skyBox = new PictureBox[90];
            rnd = new Random();
            for (int i = 0; i < skyBox.Length; i++)
            {
                skyBox[i] = new PictureBox();
                skyBox[i].BorderStyle = BorderStyle.None;
                skyBox[i].Location = new Point(rnd.Next(0, 1600), rnd.Next(-10, 900));
                if (i % 2 == 1)
                {
                    skyBox[i].Size = new Size(4, 4);
                    skyBox[i].BackColor = Color.FromArgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255));
                }
                this.Controls.Add(skyBox[i]);
                //Ovenfor laver vi stjernerne, placerer dem tilf�ldigt og smider dem i vores pictureBox liste, for at kunne smide dem igennem sk�rmen
            }
            //Vi smider 5 fjender ind til at starte med
            for (int i = 0; i < 9; i++)
            {
                PictureBox enemyBox = new PictureBox();
                enemyBox.Size = new Size(width, height);
                enemyBox.Location = new Point(10 + (width + 100)*i, 10);
                enemyBox.BackColor = Color.FromArgb(rnd.Next(40, 230), rnd.Next(40, 200), rnd.Next(40, 200));
                enemy.Add(enemyBox);
                this.Controls.Add(enemyBox);
            }
        }
        private void backTimer_Tick(object sender, EventArgs e)
        {
            //Er lidt tr�t af jeg startede  her
            //Funktionen for rendering af vores enemies til at fejle, hvorfor er mig en g�de.
            //Fjerner jeg den, bliver de tegnet s� p�nt 

            //Men den er lavet, det ikke en bug, det en feature for at g�re spillet sv�rer - og en ting jeg skal have unders�gt
            for (int i = 0; i < skyBox.Length / 2; i++)
            {
                //vi tager halvdelen af arayet og p� dutter fart fra vores ticker
                skyBox[i].Top += backSpeed;
                if (skyBox[i].Top >= this.Height)
                {
                    skyBox[i].Top = -skyBox[i].Height;
                }
            }
            for (int i = skyBox.Length / 2; i < skyBox.Length; i++)
            {
                //som ovenfor, men bagfra, s� vi kan 
                skyBox[i].Top += backSpeed - 2;
                if (skyBox[i].Top >= this.Height)
                {
                    skyBox[i].Top = -skyBox[i].Height;
                }
            }
        }
        //tre nedst�ende funktiobner fjekker f�lgdende 
        //KeyDownMove, har vi trykket en af vores to bev�geles knapper, s�t move til true, lad movetimeevent bev�ge os.
        //KeyUpStop, g�r det modsatte, s�tter den tilbage til false s� moveTimeEvent stopper med at bev�ge os
        private void moveTimerEvent(object sender, EventArgs e)
        {
            if (moveLeft == true && PlayerPaddle.Left > 0)
            {
                PlayerPaddle.Left -= speed;
            }
            if (moveRight == true && PlayerPaddle.Left < 1410)
            {
                PlayerPaddle.Left += speed;
            }
        }
        private void keyDownMove(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                moveLeft = true;
            }
            if (e.KeyCode == Keys.Right)
            {
                moveRight = true;
            }
        }
        private void keyUpStop(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                moveLeft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                moveRight = false;
            }
        }
        private void moveBall()
        {
            ball.Left += ballSpeedX;
            ball.Top += ballSpeedY;
        }
        private void checkBallBounds()
        {

            //Tjek om bold rammer kanter
            if (ball.Left <= 0 || ball.Right >= ClientSize.Width)
            {
                ballSpeedX = -ballSpeedX;
            }
            if (ball.Top <= 0)
            {
                ballSpeedY = -ballSpeedY;
            }
            if(ball.Bottom >= ClientSize.Height&&!form2opened)
            {
                this.Hide();
                form2opened = true;
                Form2 form2=new Form2(score);
                form2.ShowDialog();
                this.Close();

            }
           if (ball.Bounds.IntersectsWith(PlayerPaddle.Bounds))
            {
                //Hvis player paddle rammer bold, s�tter vi ballspeed y til negativ, s� den ryger op,
                //X retning bliver der n�st sat efter hvor langt fra midten vi rammer vores paddle
                int paddleCenter = PlayerPaddle.Left + PlayerPaddle.Width / 2;
                int ballCenter = ball.Left + ball.Width / 2;
                int angle = (ballCenter - paddleCenter) / 10;
                ballSpeedX = angle;
                ballSpeedY = -ballSpeedY;
            }
        }
        private void ballTick(object sender, EventArgs e)
        {
            //Vi kalder moveball og ball bounds for at se om den skal �ndre retning og ellers bev�ge den.
            moveBall();
            checkBallBounds();
        }
        private void spawnEnemy()
        {
            PictureBox enemyBox = new PictureBox();
            enemyBox.Size = new Size(width, height);
            enemyBox.Location = new Point(10 + (width + 100), 10);
            enemyBox.BackColor = Color.FromArgb(rnd.Next(40, 230), rnd.Next(40, 200), rnd.Next(40, 200));
            enemy.Add(enemyBox);
            this.Controls.Add(enemyBox);
        }
        private void moveEnemyTick(object sender, EventArgs e)
        {
            // Rul igennem vores enemy liste, og bev�g dem
            for (int i = 0; i < enemy.Count; i++)
            {
                enemy[i].Left += enemySpeed;
                if (enemy[i].Right >= ClientSize.Width || enemy[i].Left <= 0)
                {
                    enemy[i].Top += enemy[i].Height + 10; //fjenden ryger en r�kke ned hvis den rammer vores kant
                    enemy[i].Left = 0;//Teleporter fjenden tilbage til start siden, fors�t, kunne for gud ikke figure ud hvordan jeg fik dem til at zig zagge

                }
                
                enemyColision();

            } 
        }
        private void enemyColision()
        {
            for (int i = 0; i < enemy.Count; i++)
            {
                if (ball.Bounds.IntersectsWith(enemy[i].Bounds))
                {
                    this.Controls.Remove(enemy[i]);//Fjern fjende fra form
                    enemy.RemoveAt(i);//Fjern fjende fra list
                    score = score + 1;//Score stiger 1
                    pointBoard.Text = "Points: " + score;//Skriv score
                    spawnEnemy();//Spawn ny fjende
                }
                if (enemy[i].Top + enemy[i].Height > 830) {
                    Application.Exit();
                }
            }
            if (scoreDivide5() && !enemySpawned)
            {
                spawnEnemy(); // Spawn ny fjende
                enemySpeed += 2; // �g fjendens hastighed
                enemySpawned = true; // vi har spawnet en fjende 
                ballSpeedX += 1;
                ballSpeedY += 1;
            }
            else if (!scoreDivide5())
            {
                enemySpawned = false; //vi skal ikke spawne en fjende n�ste tick da vi ikke kan dividere med fem igen
            }
        }
    }
}